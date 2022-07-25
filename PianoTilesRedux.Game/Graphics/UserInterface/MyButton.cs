// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Bindables;
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
    public class MyButton : Button
    {
        public LocalisableString Text
        {
            get => SpriteText?.Text ?? default;
            set
            {
                if (!(SpriteText is null))
                {
                    SpriteText.Text = value;
                }
            }
        }

        public Color4 BackgroundColour
        {
            get => Background.Colour;
            set => Background.FadeColour(value);
        }

        public Color4 HoverColour
        {
            get => Hover.Colour;
            set => Hover.FadeColour(value);
        }

        private Color4 disabledColour = Color4.Gray;

        public Color4 DisabledColour
        {
            get => disabledColour;
            set
            {
                if (disabledColour != value)
                {
                    disabledColour = value;
                    Enabled.TriggerChange();
                }
            }
        }

        public double HoverFadeDuration { get; set; } = 200;
        public double DisabledFadeDuration { get; set; } = 200;

        protected override Container<Drawable> Content { get; }

        protected Box Hover;
        protected Box Background;
        protected SpriteText SpriteText;

        public MyButton()
        {
            AddInternal(
                Content = new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        Background = new Box
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativeSizeAxes = Axes.Both,
                        },
                        Hover = new Box
                        {
                            Alpha = 0,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            RelativeSizeAxes = Axes.Both,
                            Colour = Color4.White.Opacity(.1f),
                        },
                        SpriteText = CreateText(),
                    }
                }
            );

            Enabled.BindValueChanged(enabledChanged, true);
        }

        protected virtual SpriteText CreateText()
        {
            return new SpriteText
            {
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
                Font = MyFont.Default,
                Colour = Color4.White
            };
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            _ = Hover.FadeColour(Color4.Black.Opacity(.5f), HoverFadeDuration, Easing.OutQuint);
            return base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseUpEvent e)
        {
            base.OnMouseUp(e);
            _ = Hover.FadeColour(Color4.White.Opacity(.1f), HoverFadeDuration, Easing.OutQuint);
        }

        protected override bool OnHover(HoverEvent e)
        {
            _ = Hover.FadeIn(HoverFadeDuration, Easing.OutQuint);
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            base.OnHoverLost(e);
            _ = Hover.FadeOut(HoverFadeDuration, Easing.OutQuint);
        }

        private void enabledChanged(ValueChangedEvent<bool> e)
        {
            _ = this.FadeColour(e.NewValue ? Color4.White : DisabledColour, DisabledFadeDuration, Easing.OutQuint);
        }
    }
}
