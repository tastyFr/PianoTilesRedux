// Piano Tiles Redux:
// Made by tastyForReal (2022)

using Newtonsoft.Json;

namespace PianoTilesRedux.Game.Levels
{
    /// <summary>
    /// A class containing information about a level.
    /// </summary>
    public class LevelInfo : ILevelInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Title { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("bpms")]
        public float[] Bpms { get; set; }

        [JsonProperty("unlockType")]
        public UnlockType UnlockType { get; set; }
    }
}
