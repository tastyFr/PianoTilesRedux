// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using PianoTilesRedux.Game.Levels;
using PianoTilesRedux.Game.Screens.Select;
using PianoTilesRedux.Game.Screens.Select.Carousel;

namespace PianoTilesRedux.Game.Tests.Visual
{
    [TestFixture]
    public class TestSceneSongSelect : PianoTilesReduxTestScene
    {
        private const string long_title = "This title has an implausibly long title that will overflow";
        private const string long_artist_name =
            "Lorem ipsum dolor sit amet consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua";

        private readonly ScreenStack screenStack;
        private SongSelect songSelect;
        private readonly List<ILevelInfo> levels = new();

        public TestSceneSongSelect()
        {
            levels.Add(new LevelInfo { Title = long_title, Artist = long_artist_name });
            Add(screenStack = new ScreenStack());
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            screenStack.Push(songSelect = new SongSelect());
        }

        [Test]
        public void TestAssertSongSelectLoaded()
        {
            AddAssert("SongSelect loaded", () => songSelect.LoadState == LoadState.Loaded);
        }

        [Test]
        public void TestAddLevels()
        {
            _ = AddStep("clear levels", () => songSelect.Levels.Clear());
            AddAssert("no levels", () => !songSelect.Levels.OfType<LevelCarousel>().Any());
            _ = AddStep("add levels", () => addLevels(1000000, levels.First().Title, levels.First().Artist));
            AddAssert("has three levels", () => songSelect.Levels.OfType<LevelCarousel>().Count() == 3);
            AddAssert("last level is SpriteText", () => songSelect.Levels[^1] is SpriteText);
        }

        private void addLevels(int level, string title, string artist)
        {
            songSelect.Levels.Add(new LevelCarousel(level) { Title = title, Artist = artist });
            songSelect.Levels.Add(new LevelCarousel(level) { Title = title, Artist = artist });
            songSelect.Levels.Add(new LevelCarousel(level) { Title = title, Artist = artist });
        }
    }
}
