// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using osuTK;
using PianoTilesRedux.Game.Screens.Home;

namespace PianoTilesRedux.Game.Tests.Visual.Home
{
    public class TestScenePlayerResourcesContainer : PianoTilesReduxTestScene
    {
        private PlayerResourcesContainer container;

        [BackgroundDependencyLoader]
        private void load()
        {
            container = new();
            Add(container);
            container.OnUpdate += _ =>
                Schedule(() => container.Scale = new Vector2(Content.DrawSize.X / container.DrawSize.X));
        }
    }
}
