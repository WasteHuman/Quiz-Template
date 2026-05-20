using Cysharp.Threading.Tasks;
using Entry.Global;
using Utils.DI;

namespace Core.StateMachine.States
{
    public class BootstrapState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneNavigatorService _sceneNavigatorService;
        private readonly DIContainer _rootContainer;

        public BootstrapState(SceneNavigatorService sceneNavigatorService, GameStateMachine gameStateMachine, DIContainer rootContainer)
        {
            _sceneNavigatorService = sceneNavigatorService;
            _gameStateMachine = gameStateMachine;
            _rootContainer = rootContainer;
        }

        public async UniTask Enter()
        {
            await _sceneNavigatorService.Start();

            await _gameStateMachine.ChangeState(_rootContainer.Resolve<MainMenuState>());
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
    }
}