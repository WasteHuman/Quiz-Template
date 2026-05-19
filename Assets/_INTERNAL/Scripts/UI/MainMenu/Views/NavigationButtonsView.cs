using Core.MVVM;
using R3;
using UI.MainMenu.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu.Views
{
    public class NavigationButtonsView : MonoBehaviour, IView
    {
        private readonly CompositeDisposable _disposables = new();

        private NavigationButtonsViewModel _viewModel;

        [Header("Navigation buttons")]
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _inGameStoreButton;

        private void Start()
        {
            if(_startGameButton == null || _settingsButton == null || _exitButton == null || _inGameStoreButton == null)
                throw new MissingReferenceException($"Some button or buttons in [{name}] is null!");

            _startGameButton.onClick.AddListener(HandleStartGameButtonClick);
            _settingsButton.onClick.AddListener(HandleSettingsButtonClick);
            _exitButton.onClick.AddListener(HandleExitButtonClick);
            _inGameStoreButton.onClick.AddListener(HandleInGameStoreButtonClick);
        }

        private void OnDestroy()
        {
            _startGameButton.onClick.RemoveListener(HandleStartGameButtonClick);
            _settingsButton.onClick.RemoveListener(HandleSettingsButtonClick);
            _exitButton.onClick.RemoveListener(HandleExitButtonClick);
            _inGameStoreButton.onClick.RemoveListener(HandleInGameStoreButtonClick);

            Dispose();
        }

        public void BindViewModel(IViewModel viewModel) => _viewModel = viewModel as NavigationButtonsViewModel;

        public void Dispose()
        {
            _disposables.Dispose();
            _viewModel?.Dispose();
        }

        private void HandleStartGameButtonClick() => _viewModel.PlayButton();
        private void HandleSettingsButtonClick() => _viewModel.SettingsButton();
        private void HandleExitButtonClick() => _viewModel.ExitButton();
        private void HandleInGameStoreButtonClick() => _viewModel.StoreButton();
    }
}