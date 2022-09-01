// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using osuTK;
using PianoTilesRedux.Game.Graphics.Overlays;

namespace PianoTilesRedux.Game.Tests.Visual.Overlays
{
    public class TestScenePlayerResourcesOverlay : PianoTilesReduxTestScene
    {
        private PlayerResourcesOverlay overlay;

        [BackgroundDependencyLoader]
        private void load()
        {
            overlay = new();
            Add(overlay);
        }

        protected override void Update()
        {
            base.Update();
            overlay.Scale = new Vector2(Content.DrawSize.X / overlay.DrawSize.X);
        }
    }
}
