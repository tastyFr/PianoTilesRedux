// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Textures;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using PianoTilesRedux.Game.Screens.Select;

namespace PianoTilesRedux.Game.Tests.Visual
{
    [TestFixture]
    public class TestSceneSongSelect : PianoTilesReduxTestScene
    {
        private SafeAreaDefiningContainer container;

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            RelativeSizeAxes = Axes.Both;
            Child = container = new SafeAreaDefiningContainer
            {
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Children = new Drawable[]
                {
                    new Box { RelativeSizeAxes = Axes.Both, Colour = Color4.Black },
                    new DrawSizePreservingFillContainer
                    {
                        TargetDrawSize = new Vector2(540, 960),
                        Child = new ScreenStack(new SongSelect()) { RelativeSizeAxes = Axes.Both }
                    }
                }
            };
        }

        protected override void Update()
        {
            base.Update();
            var newSize = new Vector2(BoundingBox.Width, BoundingBox.Height);
            container.Size = new Vector2(Math.Min(newSize.Y / 16f * 9f, newSize.X), newSize.Y);
        }
    }
}
