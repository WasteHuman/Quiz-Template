using Cysharp.Threading.Tasks;
using Entry.Global;
using UnityEngine;
using Utils.DI;

namespace Core.StateMachine.States
{
    public class GameplayState : IGameState
    {
        private readonly SceneNavigatorService _sceneNavigatorService;
        private readonly GameStateMachine _gameStateMachine;
        private readonly DIContainer _rootContainer;

        public GameplayState(SceneNavigatorService sceneNavigatorService, GameStateMachine gameStateMachine, DIContainer rootContainer)
        {
            _sceneNavigatorService = sceneNavigatorService;
            _gameStateMachine = gameStateMachine;
            _rootContainer = rootContainer;
        }

        public UniTask Enter()
        {
            Debug.Log("Gameplay enter");
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }

        public async UniTask ExitToMainMenu()
        {
            await _sceneNavigatorService.LoadSceneAsync(SceneNames.MAIN_MENU);
            await _gameStateMachine.ChangeState(_rootContainer.Resolve<MainMenuState>());
        }
    }
}
