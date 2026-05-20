using SO.Global;

using System.Linq;
using UI.Core;
using UI.MainMenu;
using UI.MainMenu.Views;

using UnityEngine;

using Utils.CustomResourceLoader;

namespace Entry.Local.MainMenu
{
    public class MainMenuResourceLoader
    {
        private readonly AssetPathsConfig _assetsDatabase;

        public MainMenuResourceLoader(AssetPathsConfig assetsDatabase)
        {
            _assetsDatabase = assetsDatabase;
        }

        public NavigationButtonsView LoadNavigationView()
        {
            var viewPrefab = ResourceLoader.LoadOrThrow<NavigationButtonsView>(_assetsDatabase.AssetPaths.FirstOrDefault(asset => asset.Name == "Main menu buttons").Path);
            return Object.Instantiate(viewPrefab);
        }

        public UIRoot LoadUIRoot()
        {
            var rootViewPrefab = ResourceLoader.LoadOrThrow<UIRoot>(_assetsDatabase.AssetPaths.FirstOrDefault(asset => asset.Name == "UI Root").Path);
            return Object.Instantiate(rootViewPrefab);
        }

        public MainMenuWindow LoadMainMenuWindow()
        {
            var rootViewPrefab = ResourceLoader.LoadOrThrow<MainMenuWindow>(_assetsDatabase.AssetPaths.FirstOrDefault(asset => asset.Name == "Main menu window").Path);

            return Object.Instantiate(rootViewPrefab);
        }
    }
}