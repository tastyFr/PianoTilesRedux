// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osuTK.Graphics;

namespace PianoTilesRedux.Game.Tests.Visual
{
    [TestFixture]
    public class TestScenePortraitScreen : PianoTilesReduxTestScene
    {
        private SafeAreaDefiningContainer safeAreaContainer;
        private SpriteText text;

        [BackgroundDependencyLoader]
        private void load()
        {
            RelativeSizeAxes = Axes.Both;
            Child = safeAreaContainer = new SafeAreaDefiningContainer
            {
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Children = new Drawable[]
                {
                    new Box { RelativeSizeAxes = Axes.Both, Colour = Color4.Violet },
                    new Container
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Masking = true,
                        CornerRadius = 16,
                        Width = .9f,
                        Height = .15f,
                        Children = new Drawable[]
                        {
                            new Box { RelativeSizeAxes = Axes.Both, Colour = Color4.White },
                            text = new SpriteText
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                Font = FrameworkFont.Regular.With(size: 48),
                                Colour = Color4.Black,
                                Truncate = true,
                            },
                        }
                    }
                },
            };
        }

        protected override void Update()
        {
            base.Update();
            var newSize = new Vector2(BoundingBox.Width, BoundingBox.Height);
            safeAreaContainer.Size = new Vector2(Math.Min(newSize.Y / 16f * 9f, newSize.X), newSize.Y);
            text.Text = $@"{(int)safeAreaContainer.Size.X}x{(int)safeAreaContainer.Size.Y}";
        }
    }
}
