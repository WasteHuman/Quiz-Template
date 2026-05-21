using Cysharp.Threading.Tasks;

using Entry.Global;

using UnityEngine;

namespace Core.StateMachine.States
{
    public class MainMenuState : IGameState
    {
        private readonly SceneNavigatorService _sceneNavigatorService;
        private readonly GameStateMachine _gameStateMachine;
        private readonly StatesFactory _statesFactory;

        public MainMenuState(SceneNavigatorService sceneNavigatorService, GameStateMachine gameStateMachine, StatesFactory statesFactory)
        {
            _sceneNavigatorService = sceneNavigatorService;
            _gameStateMachine = gameStateMachine;
            _statesFactory = statesFactory;
        }

        public UniTask Enter()
        {
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            Debug.Log("Main menu exit");
            return UniTask.CompletedTask;
        }

        public async UniTask StartGame()
        {
            await _sceneNavigatorService.LoadSceneAsync(SceneNames.GAME);
            await _gameStateMachine.ChangeState(_statesFactory.CreateGameplayState());
        }
    }
}