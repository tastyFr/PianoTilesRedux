// Piano Tiles Redux:
// Made by tastyForReal (2022)

using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using PianoTilesRedux.Game.Screens;

namespace PianoTilesRedux.Game.Tests.Visual
{
    [TestFixture]
    public class TestSceneMultipleScreens : PianoTilesReduxTestScene
    {
        public TestSceneMultipleScreens()
        {
            Child = new DrawSizePreservingFillContainer
            {
                TargetDrawSize = new Vector2(540, 960),
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new Drawable[]
                {
                    new Box { RelativeSizeAxes = Axes.Both, Colour = Color4.DarkBlue },
                    new ScreenStack(new FirstTimeScreen())
                    {
                        Anchor = Anchor.TopLeft,
                        Origin = Anchor.TopLeft,
                        RelativeSizeAxes = Axes.Both,
                        Width = .5f,
                        Height = .5f
                    },
                    new ScreenStack(new FirstTimeScreen())
                    {
                        Anchor = Anchor.TopRight,
                        Origin = Anchor.TopRight,
                        RelativeSizeAxes = Axes.Both,
                        Width = .5f,
                        Height = .5f
                    },
                    new ScreenStack(new FirstTimeScreen())
                    {
                        Anchor = Anchor.BottomCentre,
                        Origin = Anchor.BottomCentre,
                        RelativeSizeAxes = Axes.Both,
                        Width = .5f,
                        Height = .5f
                    },
                }
            };
        }
    }
}
