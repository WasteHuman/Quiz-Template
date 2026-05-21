using Entry.Global;
using Utils.DI;

namespace Core.StateMachine.States
{
    public class StatesFactory
    {
        private readonly SceneNavigatorService _sceneNavigatorService;
        private readonly GameStateMachine _stateMachine;
        private readonly DIContainer _rootContainer;

        public StatesFactory(SceneNavigatorService sceneNavigatorService, GameStateMachine stateMachine, DIContainer rootContainer)
        {
            _sceneNavigatorService = sceneNavigatorService;
            _stateMachine = stateMachine;
            _rootContainer = rootContainer;
        }

        public IGameState CreateBootstrapState() => new BootstrapState(_sceneNavigatorService, _stateMachine, this);
        public IGameState CreateMainMenuState() => new MainMenuState(_sceneNavigatorService, _stateMachine, this);
        public IGameState CreateGameplayState() => new GameplayState(_sceneNavigatorService, _stateMachine, this);
    }
}