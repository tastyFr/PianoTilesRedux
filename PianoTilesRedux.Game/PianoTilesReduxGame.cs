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
        private const float design_width = 540;
        private const float design_height = 960;

        private Container container;

        private Box box;
        private DrawSizePreservingFillContainer containerScreen;

        public static Vector2 DesignResolution => new Vector2(design_width, design_height);

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(new SplashBackground { RelativeSizeAxes = Axes.Both });

            box = new Box { RelativeSizeAxes = Axes.Both, Colour = Color4.Black };

            containerScreen = new DrawSizePreservingFillContainer
            {
                TargetDrawSize = DesignResolution,
                Child = new ScreenStack(new Disclaimer()) { RelativeSizeAxes = Axes.Both }
            };

            container = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = DesignResolution,
                Children = new Drawable[] { box, containerScreen }
            };

            base.AddInternal(container);
        }

        protected override void Update()
        {
            base.Update();

            var newSize = BoundingBox.Size;
            container.Size = new Vector2(Math.Min(newSize.Y / 16f * 9f, newSize.X), newSize.Y);
        }
    }
}
