// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System.Linq;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using PianoTilesRedux.Game.Graphics;
using PianoTilesRedux.Game.Graphics.Containers;
using PianoTilesRedux.Game.Screens.Select.Carousel;

namespace PianoTilesRedux.Game.Screens.Select
{
    public class SongSelect : Screen
    {
        private FillFlowContainer carouselContainer;
        private Box box;

        private const string title = "This screen is experimental; it will be updated as more features are added.";
        private const string artist = "Please don't expect this to be perfect. Thanks for your patience!";

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                box = new Box { RelativeSizeAxes = Axes.Both, Colour = Color4.Violet },
                // Scroll container for all the levels
                new ReduxScrollContainer
                {
                    Padding = new MarginPadding { Vertical = 128 },
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        carouselContainer = new FillFlowContainer
                        {
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Direction = FillDirection.Vertical,
                            Spacing = new Vector2(0, 10),
                            ChildrenEnumerable = Enumerable
                                .Range(0, 25)
                                .Select(
                                    _ =>
                                        new LevelCarousel
                                        {
                                            Title = title,
                                            Artist = artist,
                                            Index = (_ + 1).ToString()
                                        }
                                )
                        }
                    }
                }
            };

            carouselContainer.Add(
                new SpriteText
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Text = "More levels coming soon!",
                    Font = ReduxFont.GetFont(Typeface.FuturaCondensed, size: 32),
                    Padding = new MarginPadding { Top = 48 },
                    Shadow = true
                }
            );
        }

        public override void OnEntering(ScreenTransitionEvent e)
        {
            base.OnEntering(e);

            _ = this.FadeInFromZero(500, Easing.OutQuint);
        }
    }
}
