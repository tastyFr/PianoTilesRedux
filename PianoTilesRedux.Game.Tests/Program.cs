// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework;
using osu.Framework.Platform;

namespace PianoTilesRedux.Game.Tests
{
    public static class Program
    {
        public static void Main()
        {
            using GameHost host = Host.GetSuitableDesktopHost("visual-tests");
            using PianoTilesReduxTestBrowser game = new();
            host.Run(game);
        }
    }
}
