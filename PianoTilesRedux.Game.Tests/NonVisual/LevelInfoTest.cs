// Piano Tiles Redux:
// Made by tastyForReal (2022)

using System;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using osu.Framework.Testing;
using PianoTilesRedux.Game.Levels;

namespace PianoTilesRedux.Game.Tests.NonVisual
{
    [HeadlessTest]
    public class LevelInfoTest
    {
        private const string filename = "LittleStar.json";
        private readonly TemporaryNativeStorage storage;
        private readonly LevelInfo levelInfo;

        public LevelInfoTest()
        {
            storage = new TemporaryNativeStorage(Guid.NewGuid().ToString());

            levelInfo = new LevelInfo
            {
                Id = 1,
                Title = filename,
                Artist = "Traditional",
                Bpms = new float[3] { 85, 90, 94 },
                Difficulty = Difficulty.VeryEasy,
                UnlockType = UnlockType.PlayerLevel,
                Source = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
            };
        }

        private void serialize()
        {
            using var stream = storage.CreateFileSafely(filename);
            using var writer = new StreamWriter(stream);
            writer.WriteLine(JsonConvert.SerializeObject(levelInfo));
        }

        [Test]
        public void TestDeserialize()
        {
            Assert.DoesNotThrow(serialize);

            using var reader = new StreamReader(storage.GetStream(filename));
            Assert.NotNull(reader);

            string value = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject<LevelInfo>(value);

            Assert.AreEqual(levelInfo.Id, data.Id);
            Assert.AreEqual(levelInfo.Title, data.Title);
            Assert.AreEqual(levelInfo.Artist, data.Artist);
            Assert.AreEqual(levelInfo.Bpms, data.Bpms);
            Assert.AreEqual(levelInfo.Difficulty, data.Difficulty);
            Assert.AreEqual(levelInfo.UnlockType, data.UnlockType);
            Assert.AreEqual(levelInfo.Source, data.Source);
        }
    }
}
