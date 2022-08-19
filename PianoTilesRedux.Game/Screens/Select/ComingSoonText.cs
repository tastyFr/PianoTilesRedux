// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using PianoTilesRedux.Game.Graphics;

namespace PianoTilesRedux.Game.Screens.Select
{
    internal class ComingSoonText : SpriteText
    {
        public ComingSoonText()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Text = "More levels to be added soon!";
            Font = ReduxFont.GetFont(Typeface.FuturaCondensed, size: 32);
            Margin = new MarginPadding { Top = 48 };
            Shadow = true;
        }
    }
}
