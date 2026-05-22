using Core.UI;

using System;
using System.Collections.Generic;

using Object = UnityEngine.Object;

namespace UI.Core
{
    public class UIWindowService
    {
        private readonly Dictionary<Type, UIWindow> _windows = new();

        private readonly IUIFactory _factory;
        private readonly UIRoot _root;

        public UIWindowService(IUIFactory factory, UIRoot root)
        {
            _factory = factory;
            _root = root;
        }

        public void Register<T>(T window) where T : UIWindow
        {
            _windows[typeof(T)] = window;
        }

        public T Open<T>() where T : UIWindow
        {
            Type type = typeof(T);

            if(_windows.TryGetValue(type, out UIWindow existingWindow))
            {
                existingWindow.Show();
                return (T)existingWindow;
            }

            T window = _factory.CreateWindow<T>();
            AttachWindowToRoot(window);

            Register(window);

            window.Show();

            return window;
        }

        public T Get<T>() where T : UIWindow
        {
            return (T)_windows[typeof(T)];
        }

        public void Close<T>() where T : UIWindow
        {
            Type type = typeof(T);

            if (_windows.TryGetValue(type, out UIWindow window))
            {
                window.Hide();
            }
        }

        public void Destroy<T>() where T : UIWindow
        {
            Type type = typeof(T);

            if (_windows.TryGetValue(type, out UIWindow window))
            {
                Object.Destroy(window.gameObject);

                _windows.Remove(type);
            }
        }

        private void AttachWindowToRoot(UIWindow window)
        {
            _root.AttachScreenLayer(window.transform);
        }
    }
}