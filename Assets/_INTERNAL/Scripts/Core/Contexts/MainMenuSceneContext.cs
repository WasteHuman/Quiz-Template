using Core.StateMachine.States;

using Entry.Local.Core;
using Entry.Local.MainMenu;

using SO.Global;

using UI.Core;
using UI.MainMenu;
using UI.MainMenu.Models;
using UI.MainMenu.ViewModels;

using Utils.DI;

namespace Core.Contexts
{
    public class MainMenuSceneContext : SceneContex
    {
        private UIRoot _uiRoot;

        protected override void RegisterServices(DIContainer container)
        {
            container.RegisterFactory(c => new MainMenuResourceLoader(c.Resolve<AssetPathsConfig>())).AsSingle();
            container.RegisterFactory(c => new MainMenuUIFactory(c.Resolve<MainMenuResourceLoader>())).AsSingle();

            _uiRoot = Container.Resolve<MainMenuUIFactory>().CreateUIRoot();

            container.RegisterInstance(_uiRoot);

            container.RegisterFactory(c => new NavigationButtonsModel()).AsSingle();
            container.RegisterFactory(c => new NavigationButtonsViewModel()).AsSingle();

            container.RegisterFactory(c => new MainMenuBootstrapper(
                c.Resolve<UIRoot>(),
                c.Resolve<MainMenuUIFactory>(),
                c.Resolve<NavigationButtonsModel>(),
                c.Resolve<NavigationButtonsViewModel>(),
                c.Resolve<MainMenuState>()
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