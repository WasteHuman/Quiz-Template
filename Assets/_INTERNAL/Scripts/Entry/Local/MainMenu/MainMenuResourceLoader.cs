using SO.Global;

using System.Linq;

using UI.Core;
using UI.MainMenu;
using UI.MainMenu.Views;

using Utils.CustomResourceLoader;

namespace Entry.Local.MainMenu
{
    public class MainMenuResourceLoader
    {
        private readonly AssetDatabase _assetsDatabase;

        public MainMenuResourceLoader(AssetDatabase assetsDatabase)
        {
            _assetsDatabase = assetsDatabase;
        }

        public NavigationButtonsView LoadNavigationView()
        {
            var assetPath = _assetsDatabase.Assets.Where(entry => entry.AssetType == AssetType.MainMenuUI)
                .SelectMany(entry => entry.AssetEntry)
                .FirstOrDefault(asset => asset.Name == "Main menu buttons").Path;
            var viewPrefab = ResourceLoader.LoadOrThrow<NavigationButtonsView>(assetPath);
            return viewPrefab;
        }

        public UIRoot LoadUIRoot()
        {
            var assetPath = _assetsDatabase.Assets.Where(entry => entry.AssetType == AssetType.CommonUI)
                .SelectMany(entry => entry.AssetEntry)
                .FirstOrDefault(asset => asset.Name == "UI Root").Path;
            var rootViewPrefab = ResourceLoader.LoadOrThrow<UIRoot>(assetPath);
            return rootViewPrefab;
        }

        public MainMenuWindow LoadMainMenuWindow()
        {
            var assetPath = _assetsDatabase.Assets.Where(entry => entry.AssetType == AssetType.MainMenuUI)
                .SelectMany(entry => entry.AssetEntry)
                .FirstOrDefault(asset => asset.Name == "Main menu screen layer").Path;
            var mainMenuWindowPrefab = ResourceLoader.LoadOrThrow<MainMenuWindow>(assetPath);
            return mainMenuWindowPrefab;
        }
    }
}