// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework;

namespace PianoTilesRedux.Game.Tests
{
    public static class Program
    {
        public static void Main()
        {
            using var host = Host.GetSuitableDesktopHost("visual-tests");
            using var game = new PianoTilesReduxTestBrowser();
            host.Run(game);
        }
    }
}
