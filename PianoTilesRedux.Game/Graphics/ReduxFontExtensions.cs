// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Graphics.Sprites;

namespace PianoTilesRedux.Game.Graphics
{
    public static class ReduxFontExtensions
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
            string familyString = typeface.HasValue ? ReduxFont.GetFamilyString(typeface.Value) : usage.Family;
            string weightString = weight.HasValue
                ? ReduxFont.GetWeightString(familyString, weight.Value)
                : usage.Weight;
            return usage.With(familyString, size, weightString, italics, fixedWidth);
        }
    }
}
