using System;
using System.Collections.Generic;

namespace UI.Core
{
    public class UIWindowService
    {
        private readonly Dictionary<Type, UIWindow> _windows = new();

        public void Register<T>(T window) where T : UIWindow
        {
            _windows[typeof(T)] = window;
        }

        public T Get<T>() where T : UIWindow
        {
            return (T)_windows[typeof(T)];
        }

        public void Show<T>() where T : UIWindow
        {
            Get<T>().Show();
        }

        public void Hide<T>() where T : UIWindow
        {
            Get<T>().Hide();
        }
    }
}