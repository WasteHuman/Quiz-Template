using UnityEngine;

namespace Core.StateMachine.States
{
    public class MainMenuState : IGameState
    {
        public void Enter()
        {
            Debug.Log("Main menu enter");
        }

        public void Exit()
        {
            Debug.Log("Main menu exit");
        }
    }
}