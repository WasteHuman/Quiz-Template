using Entry.Global;
using UnityEngine;

namespace Core.StateMachine.States
{
    public class BootstrapState : IGameState
    {
        private readonly SceneNavigatorService _sceneNavigatorService;

        public BootstrapState(SceneNavigatorService sceneNavigatorService) => _sceneNavigatorService = sceneNavigatorService;

        public void Enter()
        {
            Debug.Log("Bootstrap state enter");
            _sceneNavigatorService.Start();
        }

        public void Exit()
        {
            Debug.Log("Bootstrap state exit");
        }
    }
}
