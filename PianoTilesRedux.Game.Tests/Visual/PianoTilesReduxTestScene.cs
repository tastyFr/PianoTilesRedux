// Piano Tiles Redux:
// Made by tastyForReal (2022)

using osu.Framework.Testing;

namespace PianoTilesRedux.Game.Tests.Visual
{
    public class PianoTilesReduxTestScene : TestScene
    {
        protected override ITestSceneTestRunner CreateRunner()
        {
            return new PianoTilesReduxTestSceneTestRunner();
        }

        private class PianoTilesReduxTestSceneTestRunner : PianoTilesReduxGameBase, ITestSceneTestRunner
        {
            private TestSceneTestRunner.TestRunner runner;

            protected override void LoadAsyncComplete()
            {
                base.LoadAsyncComplete();
                Add(runner = new TestSceneTestRunner.TestRunner());
            }

            public void RunTestBlocking(TestScene test)
            {
                runner.RunTestBlocking(test);
            }
        }
    }
}
