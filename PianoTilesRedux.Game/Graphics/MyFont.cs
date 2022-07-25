// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Graphics.Sprites;

namespace PianoTilesRedux.Game.Graphics
{
    public static class MyFont
    {
        public const float DEFAULT_SIZE = 32;

        public static FontUsage Default => GetFont();
        public static FontUsage Futura => GetFont(Typeface.FuturaCondensed, weight: FontWeight.Regular);
        public static FontUsage Jua => GetFont(Typeface.Jua, weight: FontWeight.Regular);

        public static FontUsage GetFont(
            Typeface typeface = Typeface.Jua,
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
                getItalics(italics),
                fixedWidth
            );
        }

        // Both fonts don't have italics, so we'll just return false for now.
        private static bool getItalics(in bool italics)
        {
            return false;
        }

        public static string GetFamilyString(Typeface typeface)
        {
            return typeface switch
            {
                Typeface.FuturaCondensed => @"FuturaCondensed",
                Typeface.Jua => @"Jua",
                _ => null,
            };
        }

        public static string GetWeightString(string family, FontWeight weight)
        {
            return
                (family == GetFamilyString(Typeface.FuturaCondensed) || family == GetFamilyString(Typeface.Jua))
                && weight != FontWeight.Regular
                ? FontWeight.Regular.ToString()
                : weight.ToString();
        }
    }

    public static class MyFontExtensions
    {
        public static FontUsage With(
            this FontUsage usage,
            Typeface? typeface = null,
            float? size = null,
            FontWeight? weight = null,
            bool? italics = null,
            bool? fixedWidth = null
        )
        {
            string familyString = typeface != null ? MyFont.GetFamilyString(typeface.Value) : usage.Family;
            string weightString = weight != null ? MyFont.GetWeightString(familyString, weight.Value) : usage.Weight;
            return usage.With(familyString, size, weightString, italics, fixedWidth);
        }
    }

    public enum Typeface
    {
        FuturaCondensed,
        Jua,
    }

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
