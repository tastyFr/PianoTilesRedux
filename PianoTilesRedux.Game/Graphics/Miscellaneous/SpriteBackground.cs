// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace PianoTilesRedux.Game.Graphics.Miscellaneous
{
    public class SpriteBackground : Sprite
    {
        public string Background { get; set; }

        public SpriteBackground()
        {
            Anchor = Anchor.TopCentre;
            Origin = Anchor.TopCentre;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            Texture = textures.Get(Background);
            RelativeSizeAxes = Axes.Y;
            Height = 1;
        }

        protected override void Update()
        {
            base.Update();

            var size = Texture.Size;
            float aspectRatio = size.X / size.Y;

            Width = MathF.Ceiling(DrawHeight * aspectRatio);
        }
    }
}
