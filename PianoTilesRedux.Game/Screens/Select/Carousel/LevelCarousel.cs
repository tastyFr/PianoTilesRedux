// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System;
using System.Linq;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using osuTK.Graphics;
using PianoTilesRedux.Game.Graphics;
using PianoTilesRedux.Game.Graphics.UserInterface;

namespace PianoTilesRedux.Game.Screens.Select.Carousel
{
    public class LevelCarousel : Container
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Source { get; set; }
        public string Difficulty { get; set; }
        public string MusicId { get; set; }

        private const float box_width = 520;
        private const float box_height = 128;
        private const float box_corner_radius = 24;
        private const float card_width = 84;

        private const int fade_duration = 250;

        private readonly Color4 card_bg_color = new Color4(249, 177, 48, 255);
        private readonly Color4 card_fg_color = new Color4(251, 208, 52, 255);
        private readonly Color4 starcrown_uncounted_color = new Color4(224, 234, 244, 255);
        private readonly Color4 starcrown_counted_color = new Color4(255, 200, 46, 255);
        private readonly Color4 title_color = new Color4(33, 73, 98, 255);
        private readonly Color4 artist_color = new Color4(172, 194, 206, 255);

        private Texture starTexture;
        private Texture crownTexture;
        private Texture starTextureInCard;
        private Texture crownTextureInCard;

        private int totalStars;
        private FillFlowContainer<Sprite> stars;

        private Sprite levelCard;

        public string Index;
        public SpriteText LevelNumber;

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            starTexture = textures.Get("StarTexture");
            crownTexture = textures.Get("CrownTexture");
            starTextureInCard = textures.Get("StarTextureInCard");
            crownTextureInCard = textures.Get("CrownTextureInCard");

            RelativeSizeAxes = Axes.X;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Width = box_width / PianoTilesReduxGame.SCREEN_WIDTH;
            Height = box_height;

            Masking = true;
            CornerRadius = box_corner_radius;

            EdgeEffect = new EdgeEffectParameters
            {
                Type = EdgeEffectType.Shadow,
                Colour = Color4.Black.Opacity(0.175f),
                Offset = new Vector2(0, 4),
                Radius = 8,
            };

            Children = new Drawable[]
            {
                new Box { RelativeSizeAxes = Axes.Both, Colour = Color4.White },
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Width = card_width / box_width,
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            Name = "Rounded Box",
                            RelativeSizeAxes = Axes.Both,
                            Anchor = Anchor.CentreLeft,
                            Origin = Anchor.CentreLeft,
                            Colour = card_bg_color
                        },
                        LevelNumber = new SpriteText
                        {
                            Name = "Level Index",
                            Width = 64,
                            Colour = Color4.White,
                            Anchor = Anchor.TopLeft,
                            Origin = Anchor.TopLeft,
                            Font = ReduxFont.GetFont(typeface: Typeface.FuturaCondensed, size: 32),
                            Padding = new MarginPadding { Left = 18, Top = 8 },
                            Truncate = true
                        },
                        new SpriteText
                        {
                            Name = "Music Title",
                            Width = 420,
                            Text = Title,
                            Colour = title_color,
                            Anchor = Anchor.TopLeft,
                            Origin = Anchor.TopLeft,
                            Font = ReduxFont.GetFont(typeface: Typeface.FuturaCondensed, size: 32),
                            Padding = new MarginPadding { Left = 100, Top = 8 },
                            Truncate = true
                        },
                        new SpriteText
                        {
                            Name = "Music Artist",
                            Width = 420,
                            Text = Artist,
                            Colour = artist_color,
                            Anchor = Anchor.TopLeft,
                            Origin = Anchor.TopLeft,
                            Font = ReduxFont.GetFont(typeface: Typeface.FuturaCondensed, size: 24),
                            Padding = new MarginPadding { Left = 100, Top = 40 },
                            Truncate = true
                        },
                        levelCard = new Sprite
                        {
                            Name = "Level Card",
                            RelativeSizeAxes = Axes.Both,
                            Anchor = Anchor.BottomRight,
                            Origin = Anchor.BottomRight,
                            Colour = card_fg_color,
                            FillMode = FillMode.Fit,
                            Scale = new Vector2(0.75f),
                        },
                        stars = new FillFlowContainer<Sprite>
                        {
                            Name = "Stars",
                            RelativeSizeAxes = Axes.Both,
                            Anchor = Anchor.BottomLeft,
                            Origin = Anchor.BottomLeft,
                            Direction = FillDirection.Horizontal,
                            Spacing = new Vector2(4, 0),
                            Margin = new MarginPadding { Left = 102, Bottom = 10 },
                            ChildrenEnumerable = Enumerable.Range(0, 3).Select(_ => createStar())
                        },
                    }
                },
                new ReduxButton
                {
                    Name = "Play Button",
                    Enabled = { Value = true },
                    Size = new Vector2(150, 50),
                    Anchor = Anchor.BottomRight,
                    Origin = Anchor.BottomRight,
                    Margin = new MarginPadding { Right = 15, Bottom = 10 },
                    Masking = true,
                    CornerRadius = 24,
                    FontUsage = ReduxFont.GetFont(typeface: Typeface.FuturaCondensed, size: 36),
                    Label = "Play",
                    Action = () => totalStars = Math.Clamp(++totalStars, 0, 6)
                }
            };
        }

        private Sprite createStar()
        {
            return new Sprite
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
                FillMode = FillMode.Fit,
                Size = new Vector2(0.4f)
            };
        }

        private void updateStars()
        {
            foreach (var star in stars)
            {
                _ = star.FadeColour(starcrown_uncounted_color, fade_duration, Easing.OutQuint);
            }

            int starsCollected = totalStars % 4;

            // When the number of the total stars is greater than 3, the player has
            // collected crowns, so unlike stars, we need to add 1 to the number of
            // the total stars to show the correct number of crowns.
            int crownsCollected = (totalStars % 4) + 1;

            int starsToTake = totalStars < 4 ? starsCollected : crownsCollected;

            foreach (var star in stars.Take(starsToTake))
            {
                _ = star.FadeColour(starcrown_counted_color, fade_duration, Easing.OutQuint);
            }

            if (totalStars >= 4)
            {
                levelCard.Texture = crownTextureInCard;
                foreach (var star in stars)
                {
                    star.Texture = crownTexture;
                }
            }
            else
            {
                levelCard.Texture = starTextureInCard;
                foreach (var star in stars)
                {
                    star.Texture = starTexture;
                }
            }
        }

        protected override void Update()
        {
            base.Update();

            LevelNumber.Text = Index;
            updateStars();
        }
    }
}
