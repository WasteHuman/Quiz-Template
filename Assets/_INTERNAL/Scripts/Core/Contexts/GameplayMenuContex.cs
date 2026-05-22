using Entry.Local.Core;
using Entry.Local.GameplayMenu;

using SO.Global;

using UI.Core;

using Utils.DI;

namespace Core.Contexts
{
    public class GameplayMenuContex : SceneContex
    {
        private UIRoot _uiRoot;
        private UIWindowService _windowService;

        protected override void RegisterServices(DIContainer container)
        {
            container.RegisterFactory(c => new GameplayMenuResourceLoader(c.Resolve<AssetDatabase>())).AsSingle();
            container.RegisterFactory(c => new GameplayMenuUIFactory(c.Resolve<GameplayMenuResourceLoader>())).AsSingle();

            _uiRoot = container.Resolve<GameplayMenuUIFactory>().CreateUIRoot();
            _windowService = new UIWindowService(container.Resolve<GameplayMenuUIFactory>(), _uiRoot);

            container.RegisterInstance(_uiRoot);
            container.RegisterInstance(_windowService);

            container.RegisterFactory(c => new GameplayMenuBootstrapper(
                c.Resolve<GameplayMenuUIFactory>(), c.Resolve<UIWindowService>())).AsSingle();
        }

        protected override void Run()
        {
            Container.Resolve<GameplayMenuBootstrapper>().Run();
        }

        protected override void OnDestroy()
        {
            Container.Resolve<GameplayMenuBootstrapper>().Dispose();
        }
    }
}