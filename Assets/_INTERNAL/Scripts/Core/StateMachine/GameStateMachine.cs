using Cysharp.Threading.Tasks;

namespace Core.StateMachine
{
    public class GameStateMachine
    {
        private IGameState _currentState;

        public async UniTask ChangeState(IGameState newState)
        {
            if (_currentState != null)
               await _currentState.Exit();

            _currentState = newState;

            await _currentState.Enter();
        }
    }
}