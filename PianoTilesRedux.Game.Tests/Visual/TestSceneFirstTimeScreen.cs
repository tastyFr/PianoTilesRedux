// Piano Tiles Redux:
// Made by tastyForReal (2022)

using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using PianoTilesRedux.Game.Screens;

namespace PianoTilesRedux.Game.Tests.Visual
{
    [TestFixture]
    public class TestSceneFirstTimeScreen : PianoTilesReduxTestScene
    {
        // Add visual tests to ensure correct behaviour of your game:
        // https://github.com/ppy/osu-framework/wiki/Development-and-Testing
        // You can make changes to classes associated with the tests and they
        // will recompile and update immediately.

        public TestSceneFirstTimeScreen()
        {
            Child = new ScreenStack(new FirstTimeScreen()) { RelativeSizeAxes = Axes.Both };
        }
    }
}
