// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System.Drawing;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.IO.Stores;
using PianoTilesRedux.Resources;

namespace PianoTilesRedux.Game
{
    public class PianoTilesReduxGameBase : osu.Framework.Game
    {
        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager config)
        {
            Resources.AddStore(new DllResourceStore(typeof(PianoTilesReduxResources).Assembly));

            // Always set these values at the start of the game.
            config.SetValue(FrameworkSetting.WindowedSize, new Size(1366, 768));
            config.SetValue(FrameworkSetting.WindowedPositionX, 0.5);
            config.SetValue(FrameworkSetting.WindowedPositionY, 0.5);

            addFonts();
        }

        private void addFonts()
        {
            AddFont(Resources, "Fonts/FuturaCondensed/FuturaCondensed-Regular");
            AddFont(Resources, "Fonts/Fredoka/Fredoka-Light");
            AddFont(Resources, "Fonts/Fredoka/Fredoka-Regular");
            AddFont(Resources, "Fonts/Fredoka/Fredoka-Medium");
            AddFont(Resources, "Fonts/Fredoka/Fredoka-SemiBold");
            AddFont(Resources, "Fonts/Fredoka/Fredoka-Bold");
        }
    }
}
