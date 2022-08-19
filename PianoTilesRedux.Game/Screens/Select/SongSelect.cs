// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;
using PianoTilesRedux.Game.Graphics.Containers;
using PianoTilesRedux.Game.Screens.Select.Carousel;

namespace PianoTilesRedux.Game.Screens.Select
{
    public class SongSelect : Screen
    {
        private SpriteText comingSoonText;

        /// <summary>
        /// A <see cref="FillFlowContainer{T}"/> which contains <see cref="LevelCarousel"/>s.
        /// </summary>
        public FillFlowContainer Levels { get; set; }

        [BackgroundDependencyLoader]
        private void load()
        {
            Levels = new FillFlowContainer
            {
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
                Direction = FillDirection.Vertical,
                Spacing = new Vector2(0, 10),
                Child = comingSoonText = new ComingSoonText()
            };

            InternalChildren = new Drawable[]
            {
                new ReduxScrollContainer { RelativeSizeAxes = Axes.Both, Child = Levels }
            };
        }

        protected override void Update()
        {
            base.Update();

            if (comingSoonText == null)
            {
                return;
            }

            _ = Levels.Remove(comingSoonText);
            Levels.Add(comingSoonText = new ComingSoonText());
        }
    }
}
