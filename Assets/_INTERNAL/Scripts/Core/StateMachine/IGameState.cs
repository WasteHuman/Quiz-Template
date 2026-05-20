using Cysharp.Threading.Tasks;

namespace Core.StateMachine
{
    public interface IGameState
    {
        UniTask Enter();
        UniTask Exit();    
    }
}