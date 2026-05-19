namespace Core.StateMachine
{
    public interface IGameState
    {
        void Enter();
        void Exit();    
    }
}