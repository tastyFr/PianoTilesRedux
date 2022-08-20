// Piano Tiles Redux:
// Made by tastyForReal (2022)

namespace PianoTilesRedux.Game.Levels
{
    /// <summary>
    /// An interface containing information about a level.
    /// </summary>
    public interface ILevelInfo
    {
        /// <summary>
        /// The index of the level. Used for ordering levels.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// The name of the song.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// The artist of the song.
        /// </summary>
        string Artist { get; set; }

        /// <summary>
        /// The source where the song is from.
        /// </summary>
        string Source { get; set; }

        /// <summary>
        /// How difficult the song is.
        /// </summary>
        string Difficulty { get; set; }

        /// <summary>
        /// The BPMs of three divided parts of the song.
        /// </summary>
        float[] Bpms { get; set; }

        /// <summary>
        /// The unlock type required to unlock this level.
        /// </summary>
        UnlockType UnlockType { get; set; }
    }
}
