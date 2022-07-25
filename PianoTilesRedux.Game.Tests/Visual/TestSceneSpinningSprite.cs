// Piano Tiles Redux:
// Made by tastyForReal (2022)

using NUnit.Framework;
using osu.Framework.Graphics;
using PianoTilesRedux.Game.Elements;

namespace PianoTilesRedux.Game.Tests.Visual
{
    [TestFixture]
    public class TestSceneSpinningElement : PianoTilesReduxTestScene
    {
        // Add visual tests to ensure correct behaviour of your game:
        // https://github.com/ppy/osu-framework/wiki/Development-and-Testing
        // You can make changes to classes associated with the tests and they
        // will recompile and update immediately.

        public TestSceneSpinningElement()
        {
            Add(
                new SpinningSprite
                {
                    Texture = @"LittleStar_Disc",
                    Anchor = Anchor.Centre,
                    NewRotation = 360,
                    Duration = 10000,
                    Loop = true,
                }
            );
        }
    }
}
