// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;
using PianoTilesRedux.Game.Graphics.Overlays.ResourcesOverlay;

namespace PianoTilesRedux.Game.Graphics.Overlays
{
    public class PlayerResourcesOverlay : FillFlowContainer
    {
        private readonly Bar xpBar;
        private readonly Bar livesBar;
        private readonly Bar goldBar;
        private readonly Bar diamondsBar;

        public PlayerResourcesOverlay()
        {
            xpBar = new Bar(BarType.Xp);
            livesBar = new Bar(BarType.Lives);
            goldBar = new Bar(BarType.Gold);
            diamondsBar = new Bar(BarType.Diamonds);

            AutoSizeAxes = Axes.Both;
            Anchor = Anchor.TopCentre;
            Origin = Anchor.TopCentre;

            Direction = FillDirection.Horizontal;
            Spacing = new Vector2(10, 0);
            Margin = new MarginPadding { Top = 13 };

            InternalChildren = new[] { xpBar, livesBar, goldBar, diamondsBar };
        }
    }
}
