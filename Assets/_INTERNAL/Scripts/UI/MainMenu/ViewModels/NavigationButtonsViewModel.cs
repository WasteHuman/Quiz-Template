using Core.MVVM;
using R3;
using UI.MainMenu.Models;

namespace UI.MainMenu.ViewModels
{
    public class NavigationButtonsViewModel : IViewModel
    {
        private readonly CompositeDisposable _disposables = new();

        private NavigationButtonsModel _model;

        public void BindModel(IModel model)
        {
            _model = model as NavigationButtonsModel;
        }

        public void PlayButton() => _model.PlayButton();

        public void SettingsButton() => _model.SettingsButton();

        public void StoreButton() => _model.StoreButton();

        public void ExitButton() => _model.ExitButton();

        public void Dispose()
        {
            _disposables.Dispose();
            _model.Dispose();
        }
    }
}