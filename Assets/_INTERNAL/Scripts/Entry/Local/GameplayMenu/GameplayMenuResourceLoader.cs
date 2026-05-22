using SO.Global;

using System.Linq;

using UI.Core;
using UI.GameplayMenu;

using Utils.CustomResourceLoader;

namespace Entry.Local.GameplayMenu
{
    public class GameplayMenuResourceLoader
    {
        private readonly AssetDatabase _assetsDatabase;

        public GameplayMenuResourceLoader(AssetDatabase assetsDatabase)
        {
            _assetsDatabase = assetsDatabase;
        }

        public UIRoot LoadUIRoot()
        {
            var assetPath = _assetsDatabase.Assets.Where(entry => entry.AssetType == AssetType.CommonUI)
                .SelectMany(entry => entry.AssetEntry)
                .FirstOrDefault(asset => asset.Name == "UI Root").Path;
            var prefab = ResourceLoader.LoadOrThrow<UIRoot>(assetPath);
            return prefab;
        }

        public GameplayWindow LoadGameplayWindow()
        {
            var assetPath = _assetsDatabase.Assets.Where(entry => entry.AssetType == AssetType.GameplayUI)
                .SelectMany(entry => entry.AssetEntry)
                .FirstOrDefault(asset => asset.Name == "Gameplay menu screen layer").Path;
            var prefab = ResourceLoader.LoadOrThrow<GameplayWindow>(assetPath);
            return prefab;
        }
    }
}