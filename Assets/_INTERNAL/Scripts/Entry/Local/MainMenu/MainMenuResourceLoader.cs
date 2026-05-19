using SO.Global;
using System.Linq;
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
            var viewPrefab = ResourceLoader.LoadOrThrow<NavigationButtonsView>(_assetsDatabase.AssetPaths.FirstOrDefault(asset => asset.Name == "Main menu navitation view").Path);
            return Object.Instantiate(viewPrefab);
        }

        public UIMainRootView LoadMainRootView()
        {
            var rootViewPrefab = ResourceLoader.LoadOrThrow<UIMainRootView>(_assetsDatabase.AssetPaths.FirstOrDefault(asset => asset.Name == "UI Main root view").Path);

            return Object.Instantiate(rootViewPrefab);
        }
    }
}