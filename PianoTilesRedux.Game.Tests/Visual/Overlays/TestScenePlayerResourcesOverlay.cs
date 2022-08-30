// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using PianoTilesRedux.Game.Graphics.Overlays;

namespace PianoTilesRedux.Game.Tests.Visual.Overlays
{
    public class TestScenePlayerResourcesOverlay : PianoTilesReduxTestScene
    {
        private readonly PlayerResourcesOverlay overlay = new();

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(overlay);
        }
    }
}
