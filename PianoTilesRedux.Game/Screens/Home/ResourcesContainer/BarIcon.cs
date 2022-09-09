// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Allocation;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace PianoTilesRedux.Game.Screens.Home.ResourcesContainer
{
    internal class BarIcon : Sprite
    {
        private readonly string texture;

        public BarIcon(BarType barType)
        {
            switch (barType)
            {
                case BarType.Lives:
                    texture = "LifeIcon";
                    break;
                case BarType.Gold:
                    texture = "GoldIcon";
                    break;
                case BarType.Diamonds:
                    texture = "DiamondIcon";
                    break;
            }
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            Texture = textures.Get(texture);
        }
    }
}
