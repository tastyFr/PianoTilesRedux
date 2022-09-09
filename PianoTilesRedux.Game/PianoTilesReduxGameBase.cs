// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System.Drawing;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;
using PianoTilesRedux.Resources;

namespace PianoTilesRedux.Game
{
    public class PianoTilesReduxGameBase : osu.Framework.Game
    {
        private DependencyContainer dependencies;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        {
            return dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
        }

        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager config)
        {
            using var store = new DllResourceStore(typeof(PianoTilesReduxResources).Assembly);
            Resources.AddStore(store);

            using var resourceStore = new NamespacedResourceStore<byte[]>(Resources, @"Textures");
            using var largeStore = new LargeTextureStore(Host.Renderer, Host.CreateTextureLoaderStore(resourceStore));
            using var onlineStore = new OnlineStore();
            largeStore.AddTextureSource(Host.CreateTextureLoaderStore(onlineStore));
            dependencies.Cache(largeStore);

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
