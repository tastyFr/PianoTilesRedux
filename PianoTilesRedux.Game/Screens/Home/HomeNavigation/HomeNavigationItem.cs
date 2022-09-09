// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Animations;
using osu.Framework.Graphics.Textures;

namespace PianoTilesRedux.Game.Screens.Home.HomeNavigation
{
    public class HomeNavigationItem : TextureAnimation
    {
        private const int total_frames = 6;

        public NavigationTab Tab { get; }

        private bool selected;

        [Resolved]
        private LargeTextureStore textures { get; set; }

        public HomeNavigationItem(NavigationTab tab)
        {
            Anchor = Anchor.BottomCentre;
            Origin = Anchor.BottomCentre;
            Tab = tab;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            addFrames();
            addReversedFrames();
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            if (Tab == NavigationTab.Home)
            {
                this.GotoAndStop(6);
                return;
            }

            this.Stop();
        }

        private void addFrames()
        {
            for (int i = 0; i < total_frames; i++)
            {
                AddFrame(textures.Get($"HomeNavigationAnimations/{Tab}{i}"));
            }
        }

        private void addReversedFrames()
        {
            for (int i = total_frames; i >= 0; i--)
            {
                AddFrame(textures.Get($"HomeNavigationAnimations/{Tab}{i}"));
            }
        }

        internal void Deselect()
        {
            selected = false;

            if (CurrentFrameIndex == 6)
            {
                // Add frames back to avoid an exception being thrown for when
                // all large Texture references are lost.
                addReversedFrames();
                this.Play();
            }
        }

        internal void Select()
        {
            selected = true;

            if (CurrentFrameIndex != 6)
            {
                // Add frames back to avoid an exception being thrown for when
                // all large Texture references are lost.
                addFrames();
                this.Restart();
            }
        }

        protected override void Update()
        {
            base.Update();

            if ((selected && CurrentFrameIndex == 6) || CurrentFrameIndex == 12)
            {
                this.Stop();
            }
        }
    }
}
