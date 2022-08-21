// Piano Tiles Redux:
// Made by tastyForReal (2022)

using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Platform;

namespace PianoTilesRedux.Game.Tests.Visual
{
    [TestFixture]
    public class TestScenePianoTilesReduxGame : PianoTilesReduxTestScene
    {
        private PianoTilesReduxGame game;

        [BackgroundDependencyLoader]
        private void load(GameHost host)
        {
            game = new PianoTilesReduxGame();
            game.SetHost(host);

            AddGame(game);
        }

        /// <summary>
        /// Asserts that the game's state is loaded.
        /// </summary>
        [Test]
        public void TestGameStateLoaded()
        {
            Assert.IsTrue(game.IsLoaded);
        }
    }
}
