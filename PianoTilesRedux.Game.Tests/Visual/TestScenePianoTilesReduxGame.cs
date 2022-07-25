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
    }
}
