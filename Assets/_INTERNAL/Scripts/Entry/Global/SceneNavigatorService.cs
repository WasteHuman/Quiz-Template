using R3;

using Utils.DI;
using Utils.SceneLoader;

#if UNITY_WEBGL
using YG;
#endif

namespace Entry.Global
{
    public class SceneNavigatorService
    {
        private readonly CompositeDisposable _disposables = new();

        private readonly SceneLoaderService _sceneLoaderService;
        private readonly DIContainer _rootContainer;

        private DIContainer _cachedContainer;

        public SceneNavigatorService(SceneLoaderService sceneLoaderService, DIContainer rootContainer)
        {
            _sceneLoaderService = sceneLoaderService;
            _rootContainer = rootContainer;
        }

        public void Start()
        {
            LoadScene(SceneNames.MAIN_MENU);

#if UNITY_WEBGL
            YG2.GameReadyAPI();
#endif
        }

        public void Dispose() => _disposables.Clear();

        private void LoadScene(string sceneName)
        {
            _cachedContainer?.Dispose();
            _cachedContainer = null;

            _sceneLoaderService
                .OnSceneLoaded
                .Take(1)
                .Subscribe(_ => OnSceneLoaded(sceneName))
                .AddTo(_disposables);

            _sceneLoaderService.LoadScene(sceneName);
        }

        private void OnSceneLoaded(string sceneName)
        {
            switch (sceneName)
            {
                case SceneNames.MAIN_MENU:
                    CreateMainMenuScene();
                    break;
                case SceneNames.GAME:
                    CreateGameScene();
                    break;
                default:
                    CreateMainMenuScene();
                    break;
            }
        }

        private void CreateMainMenuScene()
        {
            var container = _cachedContainer = new(_rootContainer);
        }

        private void CreateGameScene()
        {
            var container = _cachedContainer = new(_rootContainer);
        }
    }
}