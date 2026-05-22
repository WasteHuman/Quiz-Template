using Core.HandlersBase;
using Core.StateMachine;

using Entry.Local.Core;
using Entry.Local.MainMenu;

using SO.Global;

using UI.Core;
using UI.MainMenu.Models;
using UI.MainMenu.ViewModels;

using Utils.DI;

namespace Core.Contexts
{
    public class MainMenuSceneContext : SceneContex
    {
        private UIRoot _uiRoot;
        private UIWindowService _windowService;

        protected override void RegisterServices(DIContainer container)
        {
            container.RegisterFactory(c => new MainMenuResourceLoader(c.Resolve<AssetDatabase>())).AsSingle();
            container.RegisterFactory(c => new MainMenuUIFactory(c.Resolve<MainMenuResourceLoader>())).AsSingle();

            _uiRoot = Container.Resolve<MainMenuUIFactory>().CreateUIRoot();
            _windowService = new UIWindowService(container.Resolve<MainMenuUIFactory>(), _uiRoot);

            container.RegisterInstance(_uiRoot);
            container.RegisterInstance(_windowService);

            container.RegisterFactory(c => new NavigationButtonsModel()).AsSingle();
            container.RegisterFactory(c => new NavigationButtonsViewModel()).AsSingle();
            container.RegisterFactory<IMainMenuActionsHandler>(c => new MainMenuActionHandler(c.Resolve<GameStateMachine>())).AsSingle();

            container.RegisterFactory(c => new MainMenuBootstrapper(
                c.Resolve<MainMenuUIFactory>(),
                c.Resolve<NavigationButtonsModel>(),
                c.Resolve<NavigationButtonsViewModel>(),
                c.Resolve<IMainMenuActionsHandler>(),
                c.Resolve<UIWindowService>()
            )).AsSingle();
        }

        protected override void Run()
        {
            Container.Resolve<MainMenuBootstrapper>().Run();
        }

        protected override void OnDestroy()
        {
            Container.Resolve<MainMenuBootstrapper>().Dispose();
        }
    }
}