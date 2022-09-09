// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System.Linq;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;
using PianoTilesRedux.Game.Screens.Home.HomeNavigation;

namespace PianoTilesRedux.Game.Screens.Home
{
    public class HomeBottomNavigation : FillFlowContainer
    {
        private HomeNavigationItem home,
            music,
            hall,
            store,
            settings;

        public HomeBottomNavigation()
        {
            AutoSizeAxes = Axes.Both;
            Anchor = Anchor.BottomCentre;
            Origin = Anchor.BottomCentre;
            Direction = FillDirection.Horizontal;
        }

        public NavigationTab SelectedTab { get; private set; }

        [BackgroundDependencyLoader]
        private void load()
        {
            home = new HomeNavigationItem(NavigationTab.Home);
            music = new HomeNavigationItem(NavigationTab.Music);
            hall = new HomeNavigationItem(NavigationTab.Hall);
            store = new HomeNavigationItem(NavigationTab.Store);
            settings = new HomeNavigationItem(NavigationTab.Settings);
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            AddRangeInternal(new[] { home, music, hall, store, settings });
        }

        protected override bool OnClick(ClickEvent e)
        {
            var position = e.ScreenSpaceMouseDownPosition;
            var thisItem = (HomeNavigationItem)this.Single(item => item.ScreenSpaceDrawQuad.Centre == position);
            select(thisItem);
            return base.OnClick(e);
        }

        private void select(HomeNavigationItem item)
        {
            home.Deselect();
            music.Deselect();
            hall.Deselect();
            store.Deselect();
            settings.Deselect();

            item.Select();
            SelectedTab = item.Tab;
        }
    }
}
