// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using osuTK;
using PianoTilesRedux.Game.Graphics.Containers;

namespace PianoTilesRedux.Game.Screens.SongSelect
{
    public class SongSelectScreen : Screen
    {
        private ComingSoonText comingSoonText;

        public FillFlowContainer Levels { get; set; }

        [BackgroundDependencyLoader]
        private void load()
        {
            comingSoonText = new ComingSoonText();

            Levels = new FillFlowContainer
            {
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
                Direction = FillDirection.Vertical,
                Spacing = new Vector2(0, 10),
                Child = comingSoonText
            };

            InternalChild = new ReduxScrollContainer { RelativeSizeAxes = Axes.Both, Child = Levels };

            Levels.OnUpdate += d =>
            {
                bool noSoonText = comingSoonText.Parent == null;
                if (noSoonText)
                {
                    comingSoonText = new ComingSoonText();
                    Levels.Add(comingSoonText);
                }

                var levels = Levels;
                bool soonTextIsLast = levels[^1] is ComingSoonText;
                if (!soonTextIsLast)
                {
                    _ = Levels.Remove(comingSoonText, false);
                }
            };
        }
    }
}
