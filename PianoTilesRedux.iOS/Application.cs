// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.iOS;
using UIKit;

namespace PianoTilesRedux.iOS
{
    public static class Application
    {
        public static void Main(string[] args)
        {
            UIApplication.Main(args, typeof(GameUIApplication), typeof(AppDelegate));
        }
    }
}
