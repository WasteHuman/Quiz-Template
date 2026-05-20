using Cysharp.Threading.Tasks;
using Entry.Local.Core;
using R3;
using UnityEngine;
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

        public SceneNavigatorService(SceneLoaderService sceneLoaderService, DIContainer rootContainer)
        {
            _sceneLoaderService = sceneLoaderService;
            _rootContainer = rootContainer;
        }

        public async UniTask Start()
        {
            await LoadSceneAsync(SceneNames.MAIN_MENU);

#if UNITY_WEBGL
            YG2.GameReadyAPI();
#endif
        }

        public void Dispose() => _disposables.Dispose();

        public async UniTask LoadSceneAsync(string sceneName)
        {
            await _sceneLoaderService.LoadSceneAsync(sceneName);

            var sceneContext = Object.FindAnyObjectByType<SceneContex>();
            sceneContext.Initialize(_rootContainer);
        }
    }
}