// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework;
using osu.Framework.Platform;
using PianoTilesRedux.Game;

namespace PianoTilesRedux.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using GameHost host = Host.GetSuitableDesktopHost(@"PianoTilesRedux");
            using osu.Framework.Game game = new PianoTilesReduxGame();
            host.Run(game);
        }
    }
}
