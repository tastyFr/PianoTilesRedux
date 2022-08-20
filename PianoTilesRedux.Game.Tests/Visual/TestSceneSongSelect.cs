// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.IO.Stores;
using osu.Framework.Screens;
using PianoTilesRedux.Game.Levels;
using PianoTilesRedux.Game.Screens.Select;
using PianoTilesRedux.Game.Screens.Select.Carousel;
using PianoTilesRedux.Game.Tests.Resources;

namespace PianoTilesRedux.Game.Tests.Visual
{
    [TestFixture]
    public class TestSceneSongSelect : PianoTilesReduxTestScene
    {
        private ResourceStore<byte[]> resources = null!;

        private readonly List<ILevelInfo> levels = new();

        private readonly ScreenStack screenStack;
        private SongSelect songSelect;

        public TestSceneSongSelect()
        {
            Add(screenStack = new());
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            resources = new(new DllResourceStore(TestResources.ResourceAssembly));
            screenStack.Push(songSelect = new());
        }

        [Test]
        public void TestLoaded()
        {
            Assert.AreEqual(songSelect.LoadState, LoadState.Loaded);
            Assert.IsTrue(resources.GetAvailableResources().Any());
        }

        private void deserializeAndAddLevels()
        {
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

        [Test]
        public void TestAddLevels()
        {
            _ = AddStep("deserialize and add levels", () => deserializeAndAddLevels());

            AddUntilStep("check if levels were added", () => levels.Any());

            _ = AddStep("clear levels", () => songSelect.Levels.Clear());

            AddAssert("no levels", () => !songSelect.Levels.OfType<LevelCarousel>().Any());

            _ = AddStep(
                $"add first level",
                () => addLevel(levels.First().Id, levels.First().Title, levels.First().Artist)
            );

            _ = AddStep(
                $"add last level",
                () => addLevel(levels.Last().Id, levels.Last().Title, levels.Last().Artist)
            );

            AddAssert("levels added", () => songSelect.Levels.OfType<LevelCarousel>().Any());

            AddAssert("last level is SpriteText", () => songSelect.Levels[^1] is SpriteText);
        }

        private void addLevel(int level, string title, string artist)
        {
            songSelect.Levels.Add(new LevelCarousel(level) { Title = title, Artist = artist });
        }

        private static List<LevelInfo> getLevelsList(string json)
        {
            return JsonConvert.DeserializeObject<List<LevelInfo>>(json);
        }
    }
}
