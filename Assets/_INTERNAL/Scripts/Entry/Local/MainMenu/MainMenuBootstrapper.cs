using Core.Enums.ButtonActions;
using Core.HandlersBase;

using Cysharp.Threading.Tasks;

using R3;

using UI.Core;
using UI.MainMenu;
using UI.MainMenu.Models;
using UI.MainMenu.ViewModels;

namespace Entry.Local.MainMenu
{
    public class MainMenuBootstrapper
    {
        private readonly CompositeDisposable _disposables = new();

        private readonly UIRoot _uiRoot;
        private readonly MainMenuUIFactory _factory;
        private readonly IMainMenuActionsHandler _actionHandler;

        private readonly NavigationButtonsModel _model;
        private readonly NavigationButtonsViewModel _viewModel;

        public MainMenuBootstrapper(
            UIRoot uiRoot,
            MainMenuUIFactory factory,
            NavigationButtonsModel model,
            NavigationButtonsViewModel viewModel,
            IMainMenuActionsHandler actionHandler)
        {
            _uiRoot = uiRoot;
            _factory = factory;

            _model = model;
            _viewModel = viewModel;
            _actionHandler = actionHandler;

            _model.Action
                .Subscribe(action =>
                {
                    _actionHandler.Handle(action);
                }).AddTo(_disposables);
        }

        public void Run()
        {
            _viewModel.BindModel(_model);

            var mainMenuWindow = _factory.CreateMainMenuWindow();

            _uiRoot.AttachScreenLayer(mainMenuWindow.transform);

            var navigationView = _factory.CreateNavigationButtonsView();

            mainMenuWindow.AttachView(navigationView.transform);

            navigationView.BindViewModel(_viewModel);

            mainMenuWindow.Show();
        }

        public void Dispose()
        {
            _model.Dispose();
            _disposables.Dispose();
        }
    }
}