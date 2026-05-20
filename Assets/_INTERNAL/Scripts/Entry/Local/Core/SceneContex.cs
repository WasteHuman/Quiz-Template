using UnityEngine;
using Utils.DI;

namespace Entry.Local.Core
{
    public abstract class SceneContex : MonoBehaviour
    {
        protected DIContainer Container { get; private set; }

        public void Initialize(DIContainer parentContainer)
        {
            Container = new DIContainer(parentContainer);

            RegisterServices(Container);
            Run();
        }

        protected abstract void RegisterServices(DIContainer container);
        protected abstract void Run();

        protected virtual void OnDestroy()
        {
            Container?.Dispose();
        }
    }
}