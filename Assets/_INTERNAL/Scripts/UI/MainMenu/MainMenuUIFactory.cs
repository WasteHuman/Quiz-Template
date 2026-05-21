using Entry.Local.MainMenu;

using UI.Core;
using UI.MainMenu.Views;

namespace UI.MainMenu
{
    public class MainMenuUIFactory
    {
        private readonly MainMenuResourceLoader _resourceLoader;

        public MainMenuUIFactory(MainMenuResourceLoader resourceLoader)
        {
            _resourceLoader = resourceLoader;
        }

        public UIRoot CreateUIRoot()
        {
            return _resourceLoader.LoadUIRoot();
        }

        public MainMenuWindow CreateMainMenuWindow()
        {
            return _resourceLoader.LoadMainMenuWindow();
        }

        public NavigationButtonsView CreateNavigationButtonsView()
        {
            return _resourceLoader.LoadNavigationView();
        }
    }
}