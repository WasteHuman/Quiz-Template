using Core.Enums.ButtonActions;
using Core.HandlersBase;
using Core.StateMachine.States;

using Cysharp.Threading.Tasks;

using UnityEngine;

namespace Entry.Local.MainMenu
{
    public class MainMenuActionHandler : IMainMenuActionsHandler
    {
        private readonly MainMenuState _state;

        public MainMenuActionHandler(MainMenuState state) => _state = state;

        public void Handle(MainMenuActions action)
        {
            switch (action)
            {
                case MainMenuActions.Play:
                    _state.StartGame().Forget();
                    break;
                case MainMenuActions.Settings:
                case MainMenuActions.Exit:
                case MainMenuActions.Store:
                    Debug.Log($"MainMenu action is not handled yet: {action}");
                    break;
                default:
                    Debug.LogWarning($"Unknown MainMenu action: {action}");
                    break;
            }
        }
    }
}