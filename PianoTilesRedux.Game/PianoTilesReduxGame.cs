// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using PianoTilesRedux.Game.Elements;
using PianoTilesRedux.Game.Screens;

namespace PianoTilesRedux.Game
{
    public class PianoTilesReduxGame : PianoTilesReduxGameBase
    {
        private ScreenStack menuScreen;

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(new SplashBackground { RelativeSizeAxes = Axes.Both });
            AddInternal(menuScreen = new ScreenStack { RelativeSizeAxes = Axes.Both });
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            menuScreen.Push(new FirstTimeScreen());
        }
    }
}
