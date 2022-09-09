// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;
using PianoTilesRedux.Game.Screens.Home.ResourcesContainer;

namespace PianoTilesRedux.Game.Screens.Home
{
    public class PlayerResourcesContainer : Container
    {
        private Bar xpBar,
            livesBar,
            goldBar,
            diamondsBar;

        private FillFlowContainer fillFlowContainer;

        public PlayerResourcesContainer()
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
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            AddInternal(fillFlowContainer);
        }
    }
}
