using Core.Enums.ButtonActions;

namespace Core.HandlersBase
{
    public interface IGameplayMenuActionsHandler
    {
        void Handle(GameplayMenuActions action);
    }
}