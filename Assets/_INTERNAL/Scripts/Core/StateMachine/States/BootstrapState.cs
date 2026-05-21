using Cysharp.Threading.Tasks;
using Entry.Global;
using Utils.DI;

namespace Core.StateMachine.States
{
    public class BootstrapState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneNavigatorService _sceneNavigatorService;
        private readonly StatesFactory _statesFactory;

        public BootstrapState(SceneNavigatorService sceneNavigatorService, GameStateMachine gameStateMachine, StatesFactory statesFactory)
        {
            _sceneNavigatorService = sceneNavigatorService;
            _gameStateMachine = gameStateMachine;
            _statesFactory = statesFactory;
        }

        public async UniTask Enter()
        {
            await _sceneNavigatorService.Start();

            await _gameStateMachine.ChangeState(_statesFactory.CreateMainMenuState());
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
    }
}