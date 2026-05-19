using UnityEngine;

namespace UI.MainMenu.Views
{
    public class UIMainRootView : MonoBehaviour
    {
        public void AttachView(Transform viewTransform) => viewTransform.SetParent(transform, false);
    }
}