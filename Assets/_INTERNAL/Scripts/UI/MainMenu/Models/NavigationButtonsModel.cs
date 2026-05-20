using Core.Enums.ButtonActions;
using Core.MVVM;
using R3;
using UnityEngine;

namespace UI.MainMenu.Models
{
    public class NavigationButtonsModel : IModel
    {
        private readonly Subject<MainMenuActions> _actionSubject = new();

        public Observable<MainMenuActions> Action => _actionSubject.AsObservable();

        /// <summary>
        /// Кнопка начать игру
        /// </summary>
        public void PlayButton() => _actionSubject.OnNext(MainMenuActions.Play);

        /// <summary>
        /// 
        /// </summary>
        public void SettingsButton() => _actionSubject.OnNext(MainMenuActions.Settings);

        /// <summary>
        /// Кнопка донатного магазина
        /// </summary>
        public void StoreButton() => _actionSubject.OnNext(MainMenuActions.Store);

        /// <summary>
        /// Кнопка выхода
        /// </summary>
        public void ExitButton()
        {
            _actionSubject.OnNext(MainMenuActions.Exit);
#if UNITY_ANDROID
            Application.Quit();
#endif
        }

        public void Dispose()
        {
        }
    }
}
