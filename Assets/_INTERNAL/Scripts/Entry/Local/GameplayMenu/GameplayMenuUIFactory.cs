using Core.UI;
using UI.Core;
using UI.GameplayMenu;
using Object = UnityEngine.Object;

namespace Entry.Local.GameplayMenu
{
    public class GameplayMenuUIFactory : IUIFactory
    {
        private readonly GameplayMenuResourceLoader _resourceLoader;

        public GameplayMenuUIFactory(GameplayMenuResourceLoader resourceLoader)
        {
            _resourceLoader = resourceLoader;
        }

        public UIRoot CreateUIRoot()
        {
            var prefab = _resourceLoader.LoadUIRoot();
            return Object.Instantiate(prefab);
        }

        public T CreateWindow<T>() where T : UIWindow
        {
            return typeof(T) switch
            {
                var t when t == typeof(GameplayWindow) => CreateGameplayWindow() as T,
                _ => throw new System.NotImplementedException($"No implementation for window of type {typeof(T)}"),
            };
        }

        private GameplayWindow CreateGameplayWindow()
        {
            var prefab = _resourceLoader.LoadGameplayWindow();
            return Object.Instantiate(prefab);
        }
    }
}