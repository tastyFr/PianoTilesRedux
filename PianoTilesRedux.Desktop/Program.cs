// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework;
using osu.Framework.Platform;

namespace PianoTilesRedux.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using GameHost host = Host.GetSuitableDesktopHost("PianoTilesRedux");
            using osu.Framework.Game game = new PianoTilesReduxGameDesktop();
            host.Run(game);
        }
    }
}
