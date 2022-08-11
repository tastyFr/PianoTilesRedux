// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osu.Framework.Localisation;
using osuTK.Graphics;

namespace PianoTilesRedux.Game.Graphics.UserInterface
{
    public class ReduxButton : Button
    {
        /// <summary>
        /// The duration of the fade in and fade out animations.
        /// </summary>
        public double FadeDuration { get; set; } = 250;

        protected override Container<Drawable> Content { get; }

        protected Box Background;
        protected SpriteText SpriteText;

        protected virtual SpriteText Text =>
            new SpriteText
            {
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
                Font = FontUsage
            };

        /// <summary>
        /// The text that is displayed on the button.
        /// </summary>
        public LocalisableString Label
        {
            get => SpriteText?.Text ?? default;
            set
            {
                if (SpriteText == null)
                {
                    return;
                }

                SpriteText.Text = value;
            }
        }

        /// <summary>
        /// Whether the mouse is currently hovering over the button.
        /// </summary>
        private bool hovering;

        /// <summary>
        /// Whether the button is currently being pressed.
        /// </summary>
        private bool pressing;

        private static readonly Color4 default_background_color = Color4Extensions.FromHex("#15A0E1");

        private Color4 backgroundColour = default_background_color;

        /// <summary>
        /// The colour of the button's background.
        /// </summary>
        public Color4 BackgroundColour
        {
            get => backgroundColour;
            set
            {
                backgroundColour = value;
                Background.Colour = value;
            }
        }

        private Color4 hoverColour = default_background_color.Lighten(0.1f);

        /// <summary>
        /// The colour of the button's background when the mouse is hovering over
        /// it.
        /// </summary>
        public Color4 HoverColour
        {
            get => hoverColour;
            set
            {
                hoverColour = value;
                if (hovering)
                {
                    Background.Colour = value;
                }
            }
        }

        private FontUsage fontUsage = ReduxFont.Fredoka;

        /// <summary>
        /// The font used for the button's text.
        /// </summary>
        public FontUsage FontUsage
        {
            get => fontUsage;
            set
            {
                fontUsage = value;
                SpriteText.Font = value;
            }
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            Enabled.BindValueChanged(_ => this.FadeTo(_.NewValue ? 1 : .5f, FadeDuration, Easing.OutQuint), true);
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            if (Enabled.Value)
            {
                pressing = true;
                _ = Background.FadeColour(HoverColour.Darken(0.75f), FadeDuration, Easing.OutQuint);
            }

            return base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseUpEvent e)
        {
            base.OnMouseUp(e);
            pressing = false;
            _ = Background.FadeColour(hovering ? HoverColour : BackgroundColour, FadeDuration, Easing.OutQuint);
        }

        protected override bool OnHover(HoverEvent e)
        {
            if (Enabled.Value)
            {
                hovering = true;
                _ = Background.FadeColour(
                    pressing ? HoverColour.Darken(0.75f) : HoverColour,
                    FadeDuration,
                    Easing.OutQuint
                );
            }

            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            base.OnHoverLost(e);
            hovering = false;
            _ = Background.FadeColour(BackgroundColour, FadeDuration, Easing.OutQuint);
        }

        public ReduxButton()
        {
            InternalChild = Content = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Children = new Drawable[]
                {
                    Background = new Box { RelativeSizeAxes = Axes.Both, Colour = BackgroundColour },
                    SpriteText = Text
                }
            };
        }
    }
}
