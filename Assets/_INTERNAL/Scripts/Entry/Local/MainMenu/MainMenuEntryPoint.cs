using Core.Enums.ButtonActions;
using R3;

using SO.Global;

using System.Linq;

using UI.MainMenu.Models;
using UI.MainMenu.ViewModels;
using UI.MainMenu.Views;

using UnityEngine;

using Utils.DI;

namespace Entry.Local.MainMenu
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        private MainMenuResourceLoader _resourceLoader;

        public Observable<MainMenuActions> Run(DIContainer container)
        {
            _resourceLoader = new MainMenuResourceLoader(container.Resolve<AssetPathsConfig>());
            var uiRootView = _resourceLoader.LoadMainRootView();

            CreateNavigationSystem(
                out NavigationButtonsModel navigationButtonsModel,
                out NavigationButtonsViewModel navigationButtonsViewModel,
                out NavigationButtonsView navigationButtonsView);

            uiRootView.AttachView(navigationButtonsView.transform);
            return navigationButtonsModel.Action.Where(action => action == MainMenuActions.Play);
        }

        private void CreateNavigationSystem(
            out NavigationButtonsModel navigationButtonsModel,
            out NavigationButtonsViewModel navigationButtonsViewModel,
            out NavigationButtonsView navigationButtonsView)
        {
            navigationButtonsModel = new();

            navigationButtonsViewModel = new();
            navigationButtonsViewModel.BindModel(navigationButtonsModel);
            navigationButtonsView = _resourceLoader.LoadNavigationView();
            navigationButtonsView.BindViewModel(navigationButtonsViewModel);
        }
    }
}