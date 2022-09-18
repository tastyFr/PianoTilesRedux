// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using osuTK;
using PianoTilesRedux.Game.Screens.Home;

namespace PianoTilesRedux.Game.Tests.Visual.Home
{
    public class TestScenePlayerResourcesContainer : PianoTilesReduxTestScene
    {
        private readonly PlayerResourcesContainer container;

        public TestScenePlayerResourcesContainer()
        {
            container = new();
            Add(container);
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            container.OnUpdate += d => Schedule(() => d.Scale = new Vector2(Content.DrawSize.X / d.DrawSize.X));
        }
    }
}
