// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using osuTK.Graphics;

namespace PianoTilesRedux.Game.Tests.Visual
{
    [TestFixture]
    public class TestScenePortraitScreen : PianoTilesReduxTestScene
    {
        private SafeAreaDefiningContainer container;
        private SpriteText text;

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            RelativeSizeAxes = Axes.Both;
            Child = container = new SafeAreaDefiningContainer
            {
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Children = new Drawable[]
                {
                    new Box { RelativeSizeAxes = Axes.Both, Colour = Color4.Violet },
                    new DrawSizePreservingFillContainer
                    {
                        TargetDrawSize = new Vector2(540, 960),
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Masking = true,
                        CornerRadius = 24,
                        Width = 520f / 540f,
                        Height = 128f / 960f,
                        Children = new Drawable[]
                        {
                            new Box { RelativeSizeAxes = Axes.Both, Colour = Color4.White },
                            new Container
                            {
                                RelativeSizeAxes = Axes.Both,
                                Width = 84f / 520f,
                                Children = new Drawable[]
                                {
                                    new Box
                                    {
                                        RelativeSizeAxes = Axes.Both,
                                        Anchor = Anchor.CentreLeft,
                                        Origin = Anchor.CentreLeft,
                                        Colour = Color4Extensions.FromHex("#F9B130")
                                    },
                                    new Sprite
                                    {
                                        RelativeSizeAxes = Axes.Both,
                                        Anchor = Anchor.BottomRight,
                                        Origin = Anchor.BottomRight,
                                        Texture = textures.Get("LevelCard_StarSpriteOverlay"),
                                        Colour = Color4Extensions.FromHex("#FBD54A"),
                                        FillMode = FillMode.Fit,
                                        Scale = new Vector2(0.75f)
                                    }
                                }
                            },
                            text = new SpriteText
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                Font = FrameworkFont.Regular.With(size: 48),
                                Colour = Color4.Black,
                                Truncate = true
                            }
                        }
                    }
                }
            };
        }

        protected override void Update()
        {
            base.Update();
            var newSize = new Vector2(BoundingBox.Width, BoundingBox.Height);
            container.Size = new Vector2(Math.Min(newSize.Y / 16f * 9f, newSize.X), newSize.Y);
            text.Text = $"{(int)container.Size.X}x{(int)container.Size.Y}";
        }
    }
}
