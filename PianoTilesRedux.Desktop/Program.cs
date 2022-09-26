// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework;

namespace PianoTilesRedux.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using var host = Host.GetSuitableDesktopHost("PianoTilesRedux");
            using var game = new PianoTilesReduxGameDesktop();
            host.Run(game);
        }
    }
}
