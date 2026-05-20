using UnityEngine;

namespace UI.Core
{
    public class UIRoot : MonoBehaviour
    {
        [field: SerializeField] public Transform ScreenLayer { get; private set; }

        [field: SerializeField] public Transform PopupLayer { get; private set; }

        [field: SerializeField] public Transform OverlayLayer { get; private set; }

        public void AttachScreenLayer(Transform layer)
        {
            ScreenLayer = layer;
            layer.SetParent(transform, false);
        }

        public void AttachPopupLayer(Transform layer)
        {
            PopupLayer = layer;
            layer.SetParent(transform, false);
        }

        public void AttachOverlayLayer(Transform layer)
        {
            OverlayLayer = layer;
            layer.SetParent(transform, false);
        }
    }
}