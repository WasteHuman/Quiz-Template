using Core.UI;

using UI.Core;
using UI.MainMenu;
using UI.MainMenu.Views;

using UnityEngine;

namespace Entry.Local.MainMenu
{
    public class MainMenuUIFactory : IUIFactory
    {
        private readonly MainMenuResourceLoader _resourceLoader;

        public MainMenuUIFactory(MainMenuResourceLoader resourceLoader)
        {
            _resourceLoader = resourceLoader;
        }

        public T CreateWindow<T>() where T : UIWindow
        {
            return typeof(T) switch
            {
                var t when t == typeof(MainMenuWindow) => CreateMainMenuWindow() as T,
                _ => throw new System.NotImplementedException($"No implementation for window of type {typeof(T)}"),
            };
        }

        public UIRoot CreateUIRoot()
        {
            var prefab = _resourceLoader.LoadUIRoot();
            return Object.Instantiate(prefab);
        }

        public NavigationButtonsView CreateNavigationButtonsView()
        {
            var prefab = _resourceLoader.LoadNavigationView();
            var instance = Object.Instantiate(prefab);
            return instance;
        }

        private MainMenuWindow CreateMainMenuWindow()
        {
            var prefab = _resourceLoader.LoadMainMenuWindow();
            var instance = Object.Instantiate(prefab);
            return instance;
        }
    }
}