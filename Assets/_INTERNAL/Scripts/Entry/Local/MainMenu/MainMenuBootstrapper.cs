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

        private readonly MainMenuUIFactory _factory;
        private readonly IMainMenuActionsHandler _actionHandler;
        private readonly UIWindowService _windowService;

        private readonly NavigationButtonsModel _model;
        private readonly NavigationButtonsViewModel _viewModel;

        public MainMenuBootstrapper(
            MainMenuUIFactory factory,
            NavigationButtonsModel model,
            NavigationButtonsViewModel viewModel,
            IMainMenuActionsHandler actionHandler,
            UIWindowService windowService)
        {
            _factory = factory;
            _windowService = windowService;

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

            var navigationView = _factory.CreateNavigationButtonsView();

            navigationView.BindViewModel(_viewModel);

            var mainMenuWindow = _windowService.Open<MainMenuWindow>();
            mainMenuWindow.AttachView(navigationView.transform);
        }

        public void Dispose()
        {
            _model.Dispose();
            _disposables.Dispose();
        }
    }
}