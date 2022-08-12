// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osu.Framework.Utils;
using osuTK;
using osuTK.Graphics;
using PianoTilesRedux.Game.Graphics;

namespace PianoTilesRedux.Game.Screens.Startup
{
    public class Disclaimer : Screen
    {
        private const float warning_icon_size = 128;
        private const float spacing_y = 171;

        private readonly Color4 warningIconColour = Color4.Yellow;
        private readonly Screen nextScreen = new FirstTimeScreen();
        private FillFlowContainer disclaimerContainer;
        private TextFlowContainer disclaimerText;

        public Disclaimer()
        {
            disclaimerContainer = new FillFlowContainer
            {
                Alpha = 0,
                Scale = new Vector2(0.9f),
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
                Direction = FillDirection.Vertical,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Spacing = new Vector2(0, spacing_y),
                Children = new Drawable[]
                {
                    new SpriteIcon
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Icon = FontAwesome.Solid.ExclamationTriangle,
                        Size = new Vector2(warning_icon_size),
                        Colour = warningIconColour
                    },
                    disclaimerText = new TextFlowContainer
                    {
                        Width = 480,
                        TextAnchor = Anchor.Centre,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre
                    }
                }
            };

            AddInternal(disclaimerContainer);
            setupDisclaimerText();
        }

        private string getRandomTip()
        {
            string[] tips =
            {
                "Toggle advanced frame/thread statistics with CTRL-F11.",
                "Press F11 to toggle between fullscreen, borderless, and windowed mode.",
                "Multithreading support means that even with low \"FPS\", your input and falling tiles in gameplay will be accurate.",
                "Search songs by typing in the search bar while in the level selection screen.",
                "Take a look under the hood at performance counters and enable verbose logging with CTRL-F2.",
                "You will lose a life if you quit the level after you started.",
                "You can change your skins in the settings menu.",
                "In the level selection screen, you can sort levels by name, author, or difficulty.",
                "Piano Tiles Redux has soundfonts support! You can add or remove soundfonts in the settings menu.",
                "Add your favorite levels to your favorites collection by pressing the heart icon."
            };

            return tips[RNG.Next(0, tips.Length)];
        }

        private void setupDisclaimerText()
        {
            _ = disclaimerText.AddText("This is an ", text => text.Font = ReduxFont.GetFont(size: 32));

            _ = disclaimerText.AddText(
                "early development ",
                text => text.Font = ReduxFont.GetFont(size: 32, weight: FontWeight.SemiBold)
            );

            _ = disclaimerText.AddText("build of Piano Tiles Redux.", text => text.Font = ReduxFont.GetFont(size: 32));

            disclaimerText.NewParagraph();
            disclaimerText.NewParagraph();

            _ = disclaimerText.AddText(
                "Don't expect it to be perfect. It is a work in progress.",
                text => text.Font = ReduxFont.GetFont(size: 24)
            );

            disclaimerText.NewParagraph();
            disclaimerText.NewParagraph();

            _ = disclaimerText.AddText(
                "If you find any bugs, please report them to ",
                text => text.Font = ReduxFont.GetFont(size: 24)
            );

            _ = disclaimerText.AddText(
                "tastyFr#3429",
                text =>
                {
                    text.Font = ReduxFont.GetFont(size: 24, weight: FontWeight.SemiBold);
                    text.Colour = Color4.SkyBlue;
                }
            );

            _ = disclaimerText.AddText(" on Discord.", text => text.Font = ReduxFont.GetFont(size: 24));

            disclaimerText.NewParagraph();
            disclaimerText.NewParagraph();

            _ = disclaimerText.AddText(
                "Thank you for understanding.",
                text => text.Font = ReduxFont.GetFont(size: 24)
            );

            disclaimerText.NewParagraph();
            disclaimerText.NewParagraph();
            disclaimerText.NewParagraph();

            _ = disclaimerText.AddText(
                "Today's tip: ",
                text => text.Font = ReduxFont.GetFont(size: 18, weight: FontWeight.SemiBold)
            );

            disclaimerText.NewParagraph();
            _ = disclaimerText.AddText(getRandomTip(), text => text.Font = ReduxFont.GetFont(size: 18));
        }

        public override void OnEntering(ScreenTransitionEvent e)
        {
            base.OnEntering(e);

            disclaimerContainer
                .FadeIn(500, Easing.OutQuint)
                .ScaleTo(1, 500, Easing.OutQuint)
                .Then(5000)
                .FadeOut(500, Easing.InQuint)
                .ScaleTo(0.9f, 500, Easing.InQuint)
                .Finally(_ => Scheduler.AddDelayed(() => this.Push(nextScreen), 250));
        }
    }
}
