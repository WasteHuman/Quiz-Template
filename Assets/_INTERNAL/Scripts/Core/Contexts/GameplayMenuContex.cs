using Entry.Local.Core;
using Entry.Local.GameplayMenu;

using Utils.DI;

namespace Core.Contexts
{
    public class GameplayMenuContex : SceneContex
    {
        protected override void RegisterServices(DIContainer container)
        {

        }

        protected override void Run()
        {

        }

        protected override void OnDestroy()
        {
            Container.Resolve<GameplayBootstrapper>().Dispose();
        }
    }
}