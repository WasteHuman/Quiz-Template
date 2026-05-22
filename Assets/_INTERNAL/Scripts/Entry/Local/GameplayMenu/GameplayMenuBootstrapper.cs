using UI.Core;
using UI.GameplayMenu;

namespace Entry.Local.GameplayMenu
{
    public class GameplayMenuBootstrapper
    {
        private readonly UIWindowService _windowService;
        private readonly GameplayMenuUIFactory _factory;

        public GameplayMenuBootstrapper(
            GameplayMenuUIFactory factory,
            UIWindowService windowService)
        {
            _factory = factory;
            _windowService = windowService;
        }

        public void Run()
        {
            _windowService.Open<GameplayWindow>().Show();
        }

        public void Dispose()
        {

        }
    }
}