// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using PianoTilesRedux.Game.Graphics.Miscellaneous;
using PianoTilesRedux.Game.Screens.Startup;

namespace PianoTilesRedux.Game
{
    public class PianoTilesReduxGame : PianoTilesReduxGameBase
    {
        private SafeAreaDefiningContainer container;

        private Box box;
        private DrawSizePreservingFillContainer drawSizePreservingFillContainer;

        public const float SCREEN_WIDTH = 540;
        public const float SCREEN_HEIGHT = 960;

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(new SplashBackground { RelativeSizeAxes = Axes.Both });

            box = new Box { RelativeSizeAxes = Axes.Both, Colour = Color4.Black };

            drawSizePreservingFillContainer = new DrawSizePreservingFillContainer
            {
                TargetDrawSize = new Vector2(SCREEN_WIDTH, SCREEN_HEIGHT),
                Child = new ScreenStack(new Disclaimer()) { RelativeSizeAxes = Axes.Both }
            };

            base.AddInternal(
                // A safe area container is defined here for the portrait screen.
                container = new SafeAreaDefiningContainer
                {
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Children = new Drawable[] { box, drawSizePreservingFillContainer }
                }
            );
        }

        protected override void Update()
        {
            base.Update();

            // Update the safe area container's size to match the current screen
            // size in portrait mode.
            var newSize = new Vector2(BoundingBox.Width, BoundingBox.Height);
            container.Size = new Vector2(Math.Min(newSize.Y / 16f * 9f, newSize.X), newSize.Y);
        }
    }
}
