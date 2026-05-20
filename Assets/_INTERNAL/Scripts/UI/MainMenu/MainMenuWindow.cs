using UI.Core;
using UnityEngine;

namespace UI.MainMenu
{
    public class MainMenuWindow : UIWindow
    {
        [field: SerializeField] public Transform ContentRoot { get; private set; }

        public void AttachView(Transform view) => view.SetParent(ContentRoot, false);
    }
}