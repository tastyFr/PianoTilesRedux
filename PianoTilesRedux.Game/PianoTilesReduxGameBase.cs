// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System.Drawing;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;
using osu.Framework.Platform;
using osuTK;
using PianoTilesRedux.Resources;

namespace PianoTilesRedux.Game
{
    public class PianoTilesReduxGameBase : osu.Framework.Game
    {
        protected override Container<Drawable> Content { get; }

        [Resolved]
        private GameHost host { get; set; }

        protected PianoTilesReduxGameBase()
        {
            base.Content.Add(
                Content = new DrawSizePreservingFillContainer { TargetDrawSize = new Vector2(1366, 768) }
            );
        }

        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager config)
        {
            Resources.AddStore(new DllResourceStore(typeof(PianoTilesReduxResources).Assembly));

            host.Window.Title = "Piano Tiles Redux";
            config.SetValue(FrameworkSetting.WindowedSize, new Size(1366, 768));

            addFonts();
        }

        private void addFonts()
        {
            AddFont(Resources, @"Fonts/FuturaCondensed/FuturaCondensed-Regular");
            AddFont(Resources, @"Fonts/Jua/Jua-Regular");
        }
    }
}
