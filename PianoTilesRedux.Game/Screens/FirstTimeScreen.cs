// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using PianoTilesRedux.Game.Elements;
using PianoTilesRedux.Game.Graphics;
using PianoTilesRedux.Game.Graphics.UserInterface;

namespace PianoTilesRedux.Game.Screens
{
    public class FirstTimeScreen : Screen
    {
        private SpriteText yourFirstSong;
        private SpinningSprite littleStarDisc;
        private SpriteText littleStarTitle;
        private MyButton startButton;
        private FillFlowContainer headphonesTip;

        protected override void LoadComplete()
        {
            base.LoadComplete();
            startButton.Enabled.Value = true;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new SpriteBackground { Background = @"LittleStar_Background" },
                new DrawSizePreservingFillContainer
                {
                    TargetDrawSize = new Vector2(540, 960),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Width = 1,
                    Height = .5f,
                    Children = new Drawable[]
                    {
                        yourFirstSong = new SpriteText
                        {
                            Text = @"Start with your first song!",
                            Shadow = true,
                            Anchor = Anchor.TopCentre,
                            Origin = Anchor.TopCentre,
                            Font = MyFont.GetFont(size: 32),
                        },
                        littleStarDisc = new SpinningSprite
                        {
                            Texture = @"LittleStar_Disc",
                            NewRotation = 360,
                            Duration = 10000,
                            Anchor = Anchor.Centre,
                            Scale = new Vector2(1.25f),
                            Loop = true,
                        },
                        littleStarTitle = new SpriteText
                        {
                            Text = @"Little Star",
                            Shadow = true,
                            Anchor = Anchor.BottomCentre,
                            Origin = Anchor.BottomCentre,
                            Font = MyFont.GetFont(size: 64),
                        },
                        startButton = new MyButton
                        {
                            Anchor = Anchor.BottomCentre,
                            Origin = Anchor.BottomCentre,
                            Masking = true,
                            BorderColour = Color4.White,
                            BorderThickness = 3,
                            MaskingSmoothness = 1,
                            CornerRadius = 32,
                            Text = "Play",
                            Size = new Vector2(256, 64),
                            BackgroundColour = Color4.White.Opacity(.5f),
                            Y = 96,
                            Action = () =>
                            {
                                if (startButton.Enabled.Value)
                                {
                                    startButton.Enabled.Value = false;
                                    doTransition();
                                }
                            },
                        },
                        headphonesTip = new FillFlowContainer
                        {
                            AutoSizeAxes = Axes.Both,
                            Anchor = Anchor.BottomCentre,
                            Origin = Anchor.BottomCentre,
                            Y = 170,
                            Spacing = new Vector2(10),
                            Children = new Drawable[]
                            {
                                new SpriteIcon
                                {
                                    Anchor = Anchor.BottomCentre,
                                    Origin = Anchor.BottomCentre,
                                    Icon = FontAwesome.Solid.HeadphonesAlt,
                                    Size = new Vector2(32),
                                    Colour = Color4.White,
                                    Shadow = true,
                                },
                                new SpriteText
                                {
                                    Text = @"Best with headphones",
                                    Shadow = true,
                                    Anchor = Anchor.BottomCentre,
                                    Origin = Anchor.BottomCentre,
                                    Font = MyFont.GetFont(size: 32),
                                },
                            }
                        }
                    }
                },
            };
        }

        private void doTransition()
        {
            _ = yourFirstSong.MoveToOffset(new Vector2(0, -100), 500, Easing.OutQuint).FadeOut(500, Easing.OutQuint);
            _ = littleStarDisc.FadeOut(500, Easing.OutQuint);
            _ = littleStarTitle.MoveToOffset(new Vector2(0, 100), 500, Easing.OutQuint).FadeOut(500, Easing.OutQuint);
            _ = startButton.MoveToOffset(new Vector2(0, 100), 500, Easing.OutQuint).FadeOut(500, Easing.OutQuint);
            _ = headphonesTip.MoveToOffset(new Vector2(0, 100), 500, Easing.OutQuint).FadeOut(500, Easing.OutQuint);
        }
    }
}
