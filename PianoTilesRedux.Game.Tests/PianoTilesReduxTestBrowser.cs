// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Graphics;
using osu.Framework.Graphics.Cursor;
using osu.Framework.Platform;
using osu.Framework.Testing;

namespace PianoTilesRedux.Game.Tests
{
    public class PianoTilesReduxTestBrowser : PianoTilesReduxGameBase
    {
        private TestBrowser testBrowser;
        private CursorContainer cursorContainer;

        protected override void LoadComplete()
        {
            base.LoadComplete();

            testBrowser = new TestBrowser("PianoTilesRedux");
            cursorContainer = new CursorContainer();
            AddRange(new Drawable[] { testBrowser, cursorContainer });
        }

        public override void SetHost(GameHost host)
        {
            base.SetHost(host);
            host.Window.CursorState |= CursorState.Hidden;
        }
    }
}
