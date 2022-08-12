// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace PianoTilesRedux.Game.Graphics.Miscellaneous
{
    public class SplashBackground : CompositeDrawable
    {
        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            InternalChildren = new Drawable[]
            {
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        new Box { RelativeSizeAxes = Axes.Both, Colour = Color4Extensions.FromHex("#383D72") },
                        new Container
                        {
                            RelativeSizeAxes = Axes.Both,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Children = new Drawable[]
                            {
                                new Box
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Colour = Color4Extensions.FromHex("#323766"),
                                },
                                new DrawSizePreservingFillContainer
                                {
                                    Strategy = DrawSizePreservationStrategy.Maximum,
                                    RelativeSizeAxes = Axes.Both,
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Children = new Drawable[]
                                    {
                                        new Sprite
                                        {
                                            RelativeSizeAxes = Axes.None,
                                            Anchor = Anchor.CentreLeft,
                                            Origin = Anchor.CentreLeft,
                                            Texture = textures.Get("Splash1"),
                                            Scale = new Vector2(1.25f),
                                            Margin = new MarginPadding { Left = 25 },
                                        },
                                        new Sprite
                                        {
                                            RelativeSizeAxes = Axes.None,
                                            Anchor = Anchor.CentreRight,
                                            Origin = Anchor.CentreRight,
                                            Texture = textures.Get("Splash2"),
                                            Scale = new Vector2(1.25f),
                                            Margin = new MarginPadding { Right = 25 },
                                        }
                                    }
                                }
                            },
                            Masking = true,
                            CornerRadius = 25,
                            Padding = new MarginPadding { Vertical = 10, Horizontal = 3 },
                            Width = 0.94f,
                            Height = 0.8f
                        }
                    }
                },
            };
        }
    }
}
