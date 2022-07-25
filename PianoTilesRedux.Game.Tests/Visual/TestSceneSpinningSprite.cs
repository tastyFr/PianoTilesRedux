// Piano Tiles Redux:
// Made by tastyForReal (2022)

using NUnit.Framework;
using osu.Framework.Graphics;
using PianoTilesRedux.Game.Elements;

namespace PianoTilesRedux.Game.Tests.Visual
{
    [TestFixture]
    public class TestSceneSpinningSprite : PianoTilesReduxTestScene
    {
        public TestSceneSpinningSprite()
        {
            Child = new SpinningSprite
            {
                Texture = @"LittleStar_Disc",
                Anchor = Anchor.Centre,
                NewRotation = 360,
                Duration = 10000,
                Loop = true,
            };
        }
    }
}
