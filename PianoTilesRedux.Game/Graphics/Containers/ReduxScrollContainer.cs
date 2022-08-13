// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Graphics;

namespace PianoTilesRedux.Game.Graphics.Containers
{
    public class ReduxScrollContainer : ReduxScrollContainer<Drawable>
    {
        public ReduxScrollContainer() : base() { }

        public ReduxScrollContainer(Direction direction) : base(direction) { }
    }
}
