using Core.Enums.ButtonActions;
using Core.HandlersBase;
using Core.StateMachine;
using Core.StateMachine.States;

using Cysharp.Threading.Tasks;

using UnityEngine;

namespace Entry.Local.MainMenu
{
    public class MainMenuActionHandler : IMainMenuActionsHandler
    {
        private readonly GameStateMachine _stateMachine;

        public MainMenuActionHandler(GameStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Handle(MainMenuActions action)
        {
            switch (action)
            {
                case MainMenuActions.Play:
                    StartGame().Forget();
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

        private async UniTask StartGame()
        {
            if (_stateMachine.CurrentActiveState is MainMenuState currentState)
                await currentState.StartGame();
        }
    }
}