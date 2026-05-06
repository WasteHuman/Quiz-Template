using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class UILoadingView : MonoBehaviour
    {
        [SerializeField] private GameObject _uiLoadingScreen;
        [SerializeField] private Slider _progress;

        private void Awake()
        {
            if(_progress == null)
            {
                Debug.LogError($"[UI Loading View] Loading progress is null!");
                return;
            }

            _progress.minValue = 0f;
            _progress.maxValue = 1f;
        }

        public void ShowLoadingScreen()
        {
            if(_uiLoadingScreen == null)
            {
                Debug.LogError($"[UI Loading View] Loading screen is null!");
                return;
            }

            _uiLoadingScreen.SetActive(true);
            _progress.value = 0f;
        }

        public void SetLoadingProgress(float progress) => _progress.value = progress;

        public void HideLoadingScreen()
        {
            if (_uiLoadingScreen == null)
            {
                Debug.LogError($"[UI Loading View] Loading screen is null!");
                return;
            }

            _uiLoadingScreen.SetActive(false);
        }
    }
}