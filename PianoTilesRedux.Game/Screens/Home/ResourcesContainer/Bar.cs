// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;
using PianoTilesRedux.Game.Graphics;

namespace PianoTilesRedux.Game.Screens.Home.ResourcesContainer
{
    internal class Bar : Container
    {
        private Vector2 barsize = new Vector2(103, 33);
        private Vector2 circlesize = new Vector2(43);

        private readonly BarType bartype;

        private Box whitebackground;

        private SpriteText valuetext;
        private SpriteIcon plus;

        private const string blue = "#2175F7";
        private Box bluebox;

        private const string lightblue = "#00B6F7";
        private Box lightbluebox;

        private CircularContainer bar;
        private CircularContainer xpbar;

        private CircularContainer bluecircle;
        private BarIcon icon;

        public Bar(BarType bartype)
        {
            AutoSizeAxes = Axes.Both;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            this.bartype = bartype;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            bar = new CircularContainer
            {
                Anchor = Anchor.CentreLeft,
                Origin = Anchor.CentreLeft,
                AutoSizeAxes = Axes.Both,
                Masking = true,
                Margin = new MarginPadding { Left = 22 }
            };

            whitebackground = new Box { Size = barsize, Colour = Colour4.White.Opacity(0.1f) };

            if (bartype == BarType.Xp)
            {
                bluebox = new Box { RelativeSizeAxes = Axes.Both, Colour = Colour4.FromHex(blue) };
                lightbluebox = new Box { RelativeSizeAxes = Axes.Both, Colour = Colour4.FromHex(lightblue) };

                xpbar = new CircularContainer
                {
                    Masking = true,
                    RelativeSizeAxes = Axes.X,
                    Width = 0.75f,
                    Height = barsize.Y,
                    Child = lightbluebox
                };

                valuetext = new SpriteText
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Text = "121",
                    Font = ReduxFont.GetFont(Typeface.FuturaCondensed, 36)
                };

                bluecircle = new CircularContainer
                {
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                    Size = circlesize,
                    Masking = true,
                    Children = new Drawable[] { bluebox, valuetext }
                };

                return;
            }

            icon = new BarIcon(bartype)
            {
                Anchor = Anchor.CentreLeft,
                Origin = Anchor.CentreLeft,
                Size = circlesize
            };

            valuetext = new SpriteText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "1000",
                Font = ReduxFont.GetFont(Typeface.FuturaCondensed)
            };

            plus = new SpriteIcon
            {
                Alpha = 0.5f,
                Size = new Vector2(12),
                Anchor = Anchor.CentreRight,
                Origin = Anchor.CentreRight,
                Margin = new MarginPadding { Right = 8 },
                Icon = FontAwesome.Solid.Plus
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            bar.Add(whitebackground);
            AddInternal(bar);

            if (bartype == BarType.Xp)
            {
                bar.Add(xpbar);
                AddInternal(bluecircle);
                return;
            }

            bar.AddRange(new Drawable[] { valuetext, plus });
            AddInternal(icon);
        }
    }
}
