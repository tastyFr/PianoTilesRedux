// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;
using osu.Framework.Screens;
using PianoTilesRedux.Game.Levels;
using PianoTilesRedux.Game.Screens.SongSelect;
using PianoTilesRedux.Game.Screens.SongSelect.LevelCarousel;
using PianoTilesRedux.Game.Tests.Resources;

namespace PianoTilesRedux.Game.Tests.Visual.SongSelect
{
    [TestFixture]
    public class TestSceneSongSelectScreen : PianoTilesReduxTestScene
    {
        private ResourceStore<byte[]> resources = null!;

        private readonly List<ILevelInfo> levels = new();

        private readonly ScreenStack screenStack = new();
        private readonly SongSelectScreen songSelect = new();

        public TestSceneSongSelectScreen()
        {
            Add(screenStack);
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            resources = new(new DllResourceStore(TestResources.ResourceAssembly));
            screenStack.Push(songSelect);
        }

        [Test]
        public void TestAddLevels()
        {
            _ = AddStep("deserialize", () => deserialize());

            AddUntilStep("wait for levels to add", () => levels.Any());

            _ = AddStep("clear levels", () => songSelect.Levels.Clear());

            AddAssert("empty levels", () => !songSelect.Levels.OfType<DrawableLevelCarousel>().Any());

            _ = AddStep(
                "add levels",
                () =>
                {
                    foreach (var level in levels)
                    {
                        addLevel(level.Id, level.Title, level.Artist);
                    }
                }
            );

            AddAssert("levels added", () => songSelect.Levels.OfType<DrawableLevelCarousel>().Any());

            AddAssert("last level type is Container", () => songSelect.Levels[^1] is Container);
        }

        private void deserialize()
        {
            Assert.IsNotEmpty(resources.GetAvailableResources());

            levels.Clear();
            Assert.IsEmpty(levels);

            using var level = resources.GetStream("Resources/Levels.json");
            string json = new StreamReader(level).ReadToEnd();
            var levelsList = getLevelsList(json);

            Assert.IsNotEmpty(levelsList);

            foreach (var levelInfo in levelsList)
            {
                levels.Add(levelInfo);
            }

            for (int i = 0; i < levels.Count; i++)
            {
                Assert.AreEqual(i + 1, levels[i].Id, $"Level ID {i + 1} is not sequential");
            }
        }

        private void addLevel(int level, string title, string artist)
        {
            songSelect.Levels.Add(new DrawableLevelCarousel(level) { Title = title, Artist = artist });
        }

        private static List<LevelInfo> getLevelsList(string json)
        {
            return JsonConvert.DeserializeObject<List<LevelInfo>>(json);
        }
    }
}
