// Piano Tiles Redux:
// Made by tastyForReal (2022)

using Android.App;
using osu.Framework.Android;
using PianoTilesRedux.Game;

namespace PianoTilesRedux.Android
{
    [Activity(
        ConfigurationChanges = DEFAULT_CONFIG_CHANGES,
        Exported = true,
        LaunchMode = DEFAULT_LAUNCH_MODE,
        MainLauncher = true
    )]
    public class PianoTilesReduxGameActivity : AndroidGameActivity
    {
        protected override osu.Framework.Game CreateGame()
        {
            return new PianoTilesReduxGame();
        }
    }
}
