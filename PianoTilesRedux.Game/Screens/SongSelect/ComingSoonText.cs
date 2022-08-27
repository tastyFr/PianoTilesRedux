// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osuTK;
using PianoTilesRedux.Game.Graphics;

namespace PianoTilesRedux.Game.Screens.SongSelect
{
    internal class ComingSoonText : Container
    {
        private const float width = 520;
        private const float height = 128;
        private const string text = "More levels to be expected!";

        private readonly SpriteText displayText;

        public ComingSoonText()
        {
            Size = new Vector2(width, height);

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            displayText = new SpriteText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = text,
                Font = ReduxFont.GetFont(Typeface.FuturaCondensed),
                Shadow = true
            };

            InternalChild = displayText;
        }
    }
}
