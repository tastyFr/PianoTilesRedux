// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;
using PianoTilesRedux.Game.Graphics.Overlays.ResourcesOverlay;

namespace PianoTilesRedux.Game.Graphics.Overlays
{
    public class PlayerResourcesOverlay : Container
    {
        private Bar xpBar;
        private Bar livesBar;
        private Bar goldBar;
        private Bar diamondsBar;

        private FillFlowContainer fillFlowContainer;

        public PlayerResourcesOverlay()
        {
            Anchor = Anchor.TopCentre;
            Origin = Anchor.TopCentre;
            Margin = new MarginPadding { Top = 13 };
            AutoSizeAxes = Axes.Y;
            Width = PianoTilesReduxGame.DesignResolution.X;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            xpBar = new Bar(BarType.Xp);
            livesBar = new Bar(BarType.Lives);
            goldBar = new Bar(BarType.Gold);
            diamondsBar = new Bar(BarType.Diamonds);

            fillFlowContainer = new FillFlowContainer
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                AutoSizeAxes = Axes.Both,
                Direction = FillDirection.Horizontal,
                Spacing = new Vector2(10, 0),
                Children = new[] { xpBar, livesBar, goldBar, diamondsBar }
            };

            AddInternal(fillFlowContainer);
        }
    }
}
