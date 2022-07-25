// Piano Tiles Redux:
// Made by tastyForReal (2022)

using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osuTK.Graphics;
using PianoTilesRedux.Game.Graphics;

namespace PianoTilesRedux.Game.Tests.Visual
{
    [TestFixture]
    public class TestScenePortraitScreen : PianoTilesReduxTestScene
    {
        public TestScenePortraitScreen()
        {
            Child = new DrawSizePreservingFillContainer
            {
                TargetDrawSize = new Vector2(540, 960),
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Width = 1,
                Height = .5f,
                Children = new Drawable[]
                {
                    new Box { RelativeSizeAxes = Axes.Both, Colour = Color4.DarkBlue },
                    new FillFlowContainer
                    {
                        AutoSizeAxes = Axes.Both,
                        Anchor = Anchor.BottomCentre,
                        Origin = Anchor.BottomCentre,
                        Y = 170,
                        Spacing = new Vector2(10),
                        Children = new Drawable[]
                        {
                            new SpriteIcon
                            {
                                Anchor = Anchor.BottomCentre,
                                Origin = Anchor.BottomCentre,
                                Icon = FontAwesome.Solid.HeadphonesAlt,
                                Size = new Vector2(32),
                                Colour = Color4.White,
                                Shadow = true,
                            },
                            new SpriteText
                            {
                                Text = @"Best with headphones",
                                Shadow = true,
                                Anchor = Anchor.BottomCentre,
                                Origin = Anchor.BottomCentre,
                                Font = MyFont.GetFont(size: 32),
                            },
                        }
                    }
                }
            };
        }
    }
}
