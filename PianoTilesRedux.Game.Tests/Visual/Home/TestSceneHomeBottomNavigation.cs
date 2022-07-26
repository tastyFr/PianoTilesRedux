﻿// Piano Tiles Redux:
// Made by tastyForReal (2022)

using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Testing.Input;
using osuTK;
using osuTK.Input;
using PianoTilesRedux.Game.Screens.Home;
using PianoTilesRedux.Game.Screens.Home.HomeNavigation;

namespace PianoTilesRedux.Game.Tests.Visual.Home
{
    [TestFixture]
    public class TestSceneHomeBottomNavigation : PianoTilesReduxTestScene
    {
        private readonly HomeBottomNavigation navigation;
        private readonly ManualInputManager inputManager;

        public TestSceneHomeBottomNavigation()
        {
            navigation = new();
            inputManager = new() { Child = navigation };
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(inputManager);
            navigation.OnUpdate += d => Schedule(() => d.Scale = new Vector2(Content.DrawSize.X / d.DrawSize.X));
        }

        [Test]
        public void TestNavigate()
        {
            _ = AddStep("select music", () => select(1));
            AddAssert("music selected", () => navigation.SelectedTab == NavigationTab.Music);
            _ = AddStep("select hall", () => select(2));
            AddAssert("hall selected", () => navigation.SelectedTab == NavigationTab.Hall);
            _ = AddStep("select store", () => select(3));
            AddAssert("store selected", () => navigation.SelectedTab == NavigationTab.Store);
            _ = AddStep("select settings", () => select(4));
            AddAssert("settings selected", () => navigation.SelectedTab == NavigationTab.Settings);
            _ = AddStep("select home", () => select(0));
            AddAssert("home selected", () => navigation.SelectedTab == NavigationTab.Home);
        }

        private void select(int c)
        {
            inputManager.MoveMouseTo(navigation.Children[c].ScreenSpaceDrawQuad.Centre);
            inputManager.Click(MouseButton.Left);
            _ = Schedule(() => inputManager.UseParentInput = true);
        }
    }
}
