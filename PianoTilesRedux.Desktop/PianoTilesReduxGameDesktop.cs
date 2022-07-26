// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System.Drawing;
using osu.Framework.Platform;
using PianoTilesRedux.Game;

namespace PianoTilesRedux.Desktop
{
    internal class PianoTilesReduxGameDesktop : PianoTilesReduxGame
    {
        public override void SetHost(GameHost host)
        {
            base.SetHost(host);

            var window = (SDL2DesktopWindow)host.Window;
            window.Title = "Piano Tiles Redux";
            window.MinSize = new Size(270, 480);
        }
    }
}
