// Piano Tiles Redux:
// Made by tastyForReal (2022)

using Foundation;
using osu.Framework.iOS;
using PianoTilesRedux.Game;

namespace PianoTilesRedux.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : GameAppDelegate
    {
        protected override osu.Framework.Game CreateGame()
        {
            return new PianoTilesReduxGame();
        }
    }
}
