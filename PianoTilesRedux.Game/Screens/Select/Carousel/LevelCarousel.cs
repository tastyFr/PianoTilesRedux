// Piano Tiles Redux:
// Made by tastyForReal (2022)

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
    public class LevelCarousel : SafeAreaDefiningContainer
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Source { get; set; }
        public string Difficulty { get; set; }

        public int Stars { get; set; }

        private const float width = 520;
        private const float height = 128;
        private const float radius = 24;
        private const float cover_width = 84;

        private readonly Color4 unlocked_bg_color = Color4Extensions.FromHex("#F9B130");
        private readonly Color4 unlocked_fg_color = Color4Extensions.FromHex("#FBD034");

        private readonly Color4 unachieved_color = Color4Extensions.FromHex("#E0EAF4");
        private readonly Color4 achieved_color = Color4Extensions.FromHex("#FFC82E");

        private readonly Color4 title_color = Color4Extensions.FromHex("#214962");
        private readonly Color4 artist_color = Color4Extensions.FromHex("#ACC2CE");

        private Box whiteBackground;

        private Texture playerStar;
        private Texture playerCrown;
        private FillFlowContainer<Sprite> containerStars;

        private Texture coverStar;
        private Texture coverCrown;

        private Box coverBackground;
        private Sprite coverForeground;
        private Container cover;

        private SpriteText artistText;
        private SpriteText titleText;
        private Container containerTitle;
        private Container containerArtist;
        private FillFlowContainer<Container> containerHeading;

        private readonly Vector2 buttonSize = new Vector2(150, 50);
        private ReduxButton playButton;

        private readonly int levelNumber;
        private SpriteText numberText;

        public LevelCarousel(int levelNumber)
        {
            this.levelNumber = levelNumber;

            Name = "Level Carousel";

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Size = new Vector2(width, height);

            Masking = true;
            CornerRadius = radius;

            EdgeEffect = new EdgeEffectParameters
            {
                Type = EdgeEffectType.Shadow,
                Colour = Color4.Black.Opacity(0.175f),
                Offset = new Vector2(0, 4),
                Radius = 8,
            };
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            playerStar = textures.Get("StarTexture");
            playerCrown = textures.Get("CrownTexture");

            coverStar = textures.Get("StarForeground");
            coverCrown = textures.Get("CrownForeground");

            whiteBackground = new Box
            {
                Name = "White Background",
                RelativeSizeAxes = Axes.Both,
                Colour = Color4.White
            };

            titleText = new SpriteText
            {
                Name = "Title Text",
                Text = Title,
                Colour = title_color,
                Font = ReduxFont.GetFont(typeface: Typeface.FuturaCondensed, size: 32),
                Width = 400,
                Truncate = true
            };

            artistText = new SpriteText
            {
                Name = "Artist Text",
                Text = Artist,
                Colour = artist_color,
                Font = ReduxFont.GetFont(typeface: Typeface.FuturaCondensed, size: 24),
                Width = 400,
                Truncate = true
            };

            containerTitle = new Container
            {
                Name = "Title",
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Child = titleText
            };

            containerArtist = new Container
            {
                Name = "Artist",
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Child = artistText
            };

            containerHeading = new FillFlowContainer<Container>
            {
                Name = "Level Heading",
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Margin = new MarginPadding { Left = 100, Top = 8 },
                Direction = FillDirection.Vertical,
                Children = new[] { containerTitle, containerArtist }
            };

            numberText = new SpriteText
            {
                Name = "Number",
                Colour = Color4.White,
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Font = ReduxFont.GetFont(typeface: Typeface.FuturaCondensed, size: 32),
                Margin = new MarginPadding { Left = 18, Top = 8 },
                Width = cover_width - 18,
                Truncate = true
            };

            coverBackground = new Box
            {
                Name = "Cover Background",
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.CentreLeft,
                Origin = Anchor.CentreLeft,
                Colour = unlocked_bg_color
            };

            coverForeground = new Sprite
            {
                Name = "Cover Foreground",
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.BottomRight,
                Origin = Anchor.BottomRight,
                Colour = unlocked_fg_color,
                FillMode = FillMode.Fit,
                Scale = new Vector2(0.75f),
            };

            cover = new Container
            {
                Name = "Cover",
                RelativeSizeAxes = Axes.Y,
                Width = cover_width,
                Children = new Drawable[] { coverBackground, coverForeground, numberText }
            };

            containerStars = new FillFlowContainer<Sprite>
            {
                Name = "Stars",
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
                Direction = FillDirection.Horizontal,
                Spacing = new Vector2(4, 0),
                Margin = new MarginPadding { Left = 102, Bottom = 10 },
                Children = new[] { star, star, star }
            };

            playButton = new ReduxButton
            {
                Name = "Play Button",
                Enabled = { Value = true },
                Size = buttonSize,
                Anchor = Anchor.BottomRight,
                Origin = Anchor.BottomRight,
                Margin = new MarginPadding { Right = 15, Bottom = 10 },
                Masking = true,
                CornerRadius = 24,
                FontUsage = ReduxFont.GetFont(typeface: Typeface.FuturaCondensed, size: 36),
                Label = "Play"
            };

            Children = new Drawable[] { whiteBackground, cover, containerHeading, containerStars, playButton };
        }

        private Sprite star =>
            new Sprite
            {
                Name = "Star",
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
                FillMode = FillMode.Fit,
                Size = new Vector2(0.4f)
            };

        private void updateStars()
        {
            foreach (var s in containerStars)
            {
                s.Colour = unachieved_color;
            }

            int starsCollected = Stars % 4;

            int crownsCollected = (Stars % 4) + 1;

            int starsToTake = Stars < 4 ? starsCollected : crownsCollected;

            foreach (var s in containerStars.Take(starsToTake))
            {
                s.Colour = achieved_color;
            }

            if (Stars >= 4)
            {
                coverForeground.Texture = coverCrown;
                foreach (var s in containerStars)
                {
                    s.Texture = playerCrown;
                }
            }
            else
            {
                coverForeground.Texture = coverStar;
                foreach (var s in containerStars)
                {
                    s.Texture = playerStar;
                }
            }
        }

        protected override void Update()
        {
            base.Update();

            numberText.Text = levelNumber.ToString();
            updateStars();
        }
    }
}
