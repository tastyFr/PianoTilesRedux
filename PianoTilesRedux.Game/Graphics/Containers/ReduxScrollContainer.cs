// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace PianoTilesRedux.Game.Graphics.Containers
{
    public class ReduxScrollContainer : ReduxScrollContainer<Drawable>
    {
        public ReduxScrollContainer() : base() { }

        public ReduxScrollContainer(Direction direction) : base(direction) { }
    }

    public class ReduxScrollContainer<T> : ScrollContainer<T> where T : Drawable
    {
        public ReduxScrollContainer(Direction direction = Direction.Vertical) : base(direction) { }

        protected override ScrollbarContainer CreateScrollbar(Direction direction)
        {
            return new ReduxScrollBar(direction);
        }

        protected class ReduxScrollBar : ScrollbarContainer
        {
            public ReduxScrollBar(Direction direction) : base(direction)
            {
                Masking = true;
                CornerRadius = 4f;
                Child = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.White,
                    Alpha = 0.5f
                };
            }

            public override void ResizeTo(float val, int duration = 0, Easing easing = Easing.None)
            {
                Vector2 newSize = new Vector2(8f);
                int scrollDirection = (int)ScrollDirection;
                newSize[scrollDirection] = val;
                _ = this.ResizeTo(newSize, duration, easing);
            }
        }
    }
}
