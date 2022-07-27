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
using PianoTilesRedux.Game.Elements;
using PianoTilesRedux.Game.Screens;

namespace PianoTilesRedux.Game
{
    public class PianoTilesReduxGame : PianoTilesReduxGameBase
    {
        private ScreenStack screen;
        private SafeAreaDefiningContainer safeAreaContainer;

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(new SplashBackground { RelativeSizeAxes = Axes.Both });
            AddInternal(
                // A safe area container is defined here for the portrait screen.
                safeAreaContainer = new SafeAreaDefiningContainer
                {
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Children = new Drawable[]
                    {
                        new Box { RelativeSizeAxes = Axes.Both, Colour = Color4.Black },
                        screen = new ScreenStack(new FirstTimeScreen()) { RelativeSizeAxes = Axes.Both }
                    }
                }
            );
        }

        protected override void Update()
        {
            base.Update();

            // Update the safe area container's size to match the current screen
            // size in portrait mode.
            var newSize = new Vector2(BoundingBox.Width, BoundingBox.Height);
            safeAreaContainer.Size = new Vector2(Math.Min(newSize.Y / 16f * 9f, newSize.X), newSize.Y);
        }
    }
}
