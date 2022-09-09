// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osuTK.Graphics;

namespace PianoTilesRedux.Game.Graphics.Miscellaneous
{
    public class UnderConstructionMessage : CompositeDrawable
    {
        public FillFlowContainer TextContainer { get; private set; }
        private Container boxContainer;

        private SpriteIcon topHeadingIcon;
        private SpriteText topHeadingText;
        private FillFlowContainer topHeading;

        private SpriteText bottomHeadingTopText;
        private SpriteText bottomHeadingBottomText;
        private FillFlowContainer bottomHeading;

        private readonly string name;
        private readonly string description;

        public UnderConstructionMessage(string name, string description = "is not yet ready for use!")
        {
            AutoSizeAxes = Axes.Both;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            this.name = name;
            this.description = description;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            boxContainer = new Container
            {
                Masking = true,
                CornerRadius = 24,
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Child = new Box { RelativeSizeAxes = Axes.Both, Colour = Color4.White.Opacity(0.25f) }
            };

            topHeadingIcon = new SpriteIcon
            {
                Icon = FontAwesome.Solid.UniversalAccess,
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Size = new Vector2(50),
            };

            topHeadingText = new SpriteText
            {
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Font = ReduxFont.GetFont(size: 48, weight: FontWeight.SemiBold),
                Text = name
            };

            topHeading = new FillFlowContainer
            {
                Direction = FillDirection.Vertical,
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Spacing = new Vector2(0, 6),
                Children = new Drawable[] { topHeadingIcon, topHeadingText }
            };

            bottomHeadingTopText = new SpriteText
            {
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Font = ReduxFont.GetFont(size: 32, weight: FontWeight.Regular),
                Text = description
            };

            bottomHeadingBottomText = new SpriteText
            {
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Font = ReduxFont.GetFont(size: 24, weight: FontWeight.Regular),
                Text = "please check back a bit later."
            };

            bottomHeading = new FillFlowContainer
            {
                Direction = FillDirection.Vertical,
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Spacing = new Vector2(0, 5),
                Children = new[] { bottomHeadingTopText, bottomHeadingBottomText }
            };

            TextContainer = new FillFlowContainer
            {
                Direction = FillDirection.Vertical,
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Padding = new MarginPadding(24),
                Children = new[] { topHeading, bottomHeading }
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            boxContainer.Add(TextContainer);
            AddInternal(boxContainer);

            boxContainer.Hide();
            _ = boxContainer.ScaleTo(0.25f);
            _ = boxContainer.RotateTo(-15);

            using (BeginAbsoluteSequence(1000, true))
            {
                _ = boxContainer.FadeIn(1000, Easing.OutExpo);
                _ = boxContainer.ScaleTo(1, 1000, Easing.OutElastic);
                _ = boxContainer.RotateTo(0, 500, Easing.OutElastic);
            }
        }
    }
}
