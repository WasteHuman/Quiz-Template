using UI.Core;
using UnityEngine;

namespace UI.GameplayMenu
{
    public class GameplayWindow : UIWindow
    {
        [SerializeField] private Transform _contentRoot;

        public void AttachView(Transform view) => view.SetParent(_contentRoot, false);
    }
}