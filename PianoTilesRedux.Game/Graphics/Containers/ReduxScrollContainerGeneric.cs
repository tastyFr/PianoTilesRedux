// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace PianoTilesRedux.Game.Graphics.Containers
{
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
                CornerRadius = 4;
                Child = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.White,
                    Alpha = 0.5f
                };
            }

            public override void ResizeTo(float val, int duration = 0, Easing easing = Easing.None)
            {
                _ = this.ResizeTo(new Vector2(8) { [(int)ScrollDirection] = val }, duration, easing);
            }
        }
    }
}
