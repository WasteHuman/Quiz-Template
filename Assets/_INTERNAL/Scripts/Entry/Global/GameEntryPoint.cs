using Common;
using Cysharp.Threading.Tasks;
using SO.Global;
using System;

using UnityEngine;

using Utils.CustomResourceLoader;
using Utils.DI;
using Utils.SceneLoader;

namespace Entry.Global
{
    public class GameEntryPoint
    {
        private static GameEntryPoint _instance;

        private readonly DIContainer _rootContainer = new();
        private readonly AssetsPathsConfig _assetsPathsConfig;

        private readonly SceneNavigatorService _sceneNavigatorService;

        private readonly UILoadingView _loadingView;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStart()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            _instance = new GameEntryPoint();

            RunAsync().Forget();

#if UNITY_ANDROID
            Application.quitting += HandleApplicationQuit;
#endif
        }

        private GameEntryPoint()
        {
            _assetsPathsConfig = ResourceLoader.LoadOrThrow<AssetsPathsConfig>("Configs/Global/AssetsPathsConfig");
            var loadingViewPrefab = ResourceLoader.LoadOrThrow<UILoadingView>("UI/Common/UILoadingView");

            _loadingView = UnityEngine.Object.Instantiate(loadingViewPrefab);

            RegisterGlobalServices();

            var sls = _rootContainer.Resolve<SceneLoaderService>();
            _sceneNavigatorService = new(sls, _rootContainer);
        }

        private static async UniTask RunAsync()
        {
            try
            {
                await _instance.Run();
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"GameEntry failed: {ex.GetType().Name}: {ex.Message}");
            }
        }

        private async UniTask Run()
        {
            _sceneNavigatorService.Start();
        }

        private void RegisterGlobalServices()
        {
            _rootContainer.RegisterInstance(_loadingView);
            _rootContainer.RegisterInstance(_assetsPathsConfig);

            var loadingView = _rootContainer.Resolve<UILoadingView>();
            _rootContainer.RegisterFactory(sls => new SceneLoaderService(loadingView)).AsSingle();
        }

#if UNITY_ANDROID
        private static void HandleApplicationQuit()
        {
            //_instance._rootContainer.Resolve<GameWorldState>().Dispose();
            _instance._sceneNavigatorService.Dispose();
            _instance._rootContainer.Dispose();
        }
#endif
    }
}