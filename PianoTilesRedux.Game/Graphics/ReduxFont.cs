// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Graphics.Sprites;

namespace PianoTilesRedux.Game.Graphics
{
    public static class ReduxFont
    {
        public const float DEFAULT_SIZE = 32;
        public static FontUsage Fredoka => GetFont();
        public static FontUsage Futura => GetFont(Typeface.FuturaCondensed, weight: FontWeight.Regular);

        /// <summary>
        /// Gets the <see cref="FontUsage" /> for the given parameters.
        /// </summary>
        public static FontUsage GetFont(
            Typeface typeface = Typeface.Fredoka,
            float size = DEFAULT_SIZE,
            FontWeight weight = FontWeight.Regular,
            bool italics = false,
            bool fixedWidth = false
        )
        {
            string familyString = GetFamilyString(typeface);
            return new FontUsage(
                familyString,
                size,
                GetWeightString(familyString, weight),
                getItalics(in italics),
                fixedWidth
            );
        }

        // Fredoka and FuturaCondensed don't support italics, so we just return
        // false for now.
        private static bool getItalics(in bool italics)
        {
            return false;
        }

        /// <summary>
        /// Gets the family string for the given typeface.
        /// </summary>
        public static string GetFamilyString(Typeface typeface)
        {
            switch (typeface)
            {
                case Typeface.FuturaCondensed:
                    return "FuturaCondensed";
                case Typeface.Fredoka:
                    return "Fredoka";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Gets the weight string for the given family and weight.
        /// </summary>
        public static string GetWeightString(string family, FontWeight weight)
        {
            return family == GetFamilyString(Typeface.Fredoka) && weight == FontWeight.Black
                ? FontWeight.Regular.ToString()
                : family == GetFamilyString(Typeface.FuturaCondensed) && weight != FontWeight.Regular
                    ? FontWeight.Regular.ToString()
                    : weight.ToString();
        }
    }

    /// <summary>
    /// The enum for the font's typeface.
    /// </summary>
    public enum Typeface
    {
        FuturaCondensed,
        Fredoka,
    }

    /// <summary>
    /// The enum for the font's weight.
    /// </summary>
    public enum FontWeight
    {
        Light = 300,
        Regular = 400,
        Medium = 500,
        SemiBold = 600,
        Bold = 700,
        Black = 900,
    }
}
