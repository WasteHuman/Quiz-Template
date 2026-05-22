using UI.Core;

namespace Core.UI
{
    public interface IUIFactory
    {
        T CreateWindow<T>() where T : UIWindow;
    }
}