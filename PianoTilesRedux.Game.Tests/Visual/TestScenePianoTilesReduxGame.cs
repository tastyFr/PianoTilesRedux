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
        // Add visual tests to ensure correct behaviour of your game:
        // https://github.com/ppy/osu-framework/wiki/Development-and-Testing
        // You can make changes to classes associated with the tests and they
        // will recompile and update immediately.

        private PianoTilesReduxGame game;

        [BackgroundDependencyLoader]
        private void load(GameHost host)
        {
            game = new PianoTilesReduxGame();
            game.SetHost(host);

            AddGame(game);
        }
    }
}
