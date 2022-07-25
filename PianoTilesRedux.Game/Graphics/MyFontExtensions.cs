// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Graphics.Sprites;

namespace PianoTilesRedux.Game.Graphics
{
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
            var familyString = typeface is null ? usage.Family : MyFont.GetFamilyString(typeface.Value);
            var weightString = weight is null ? usage.Weight : MyFont.GetWeightString(familyString, weight.Value);
            return usage.With(familyString, size, weightString, italics, fixedWidth);
        }
    }
}
