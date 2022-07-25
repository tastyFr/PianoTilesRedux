// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace PianoTilesRedux.Game.Elements
{
    public class SpinningSprite : CompositeDrawable
    {
        private Container container;
        public string Texture { get; set; }
        public float NewRotation { get; set; } = 0;
        public float Duration { get; set; } = 0;
        public Easing Easing { get; set; } = Easing.None;
        public bool Loop { get; set; } = false;

        public SpinningSprite()
        {
            AutoSizeAxes = Axes.Both;
            Origin = Anchor.Centre;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            if (string.IsNullOrWhiteSpace(Texture))
            {
                throw new ArgumentException("Texture cannot be null or empty");
            }

            InternalChild = container = new Container
            {
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new Drawable[]
                {
                    new Sprite
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Texture = textures.Get(Texture)
                    },
                }
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            _ = Loop
                ? container.Loop(e => e.RotateTo(0).RotateTo(NewRotation, Duration))
                : container.RotateTo(0).RotateTo(NewRotation, Duration, Easing);
        }
    }
}
