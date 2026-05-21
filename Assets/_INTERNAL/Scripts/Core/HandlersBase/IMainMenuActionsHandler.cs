using Core.Enums.ButtonActions;

namespace Core.HandlersBase
{
    public interface IMainMenuActionsHandler
    {
        void Handle(MainMenuActions action);
    }
}