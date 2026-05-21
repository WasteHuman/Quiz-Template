using Common;

using Core.GlobalState;
using Core.StateMachine;
using Core.StateMachine.States;
using Cysharp.Threading.Tasks;

using SO.Global;

using System;
using System.Linq;

using UnityEngine;

using Utils.CustomResourceLoader;
using Utils.DI;
using Utils.SceneLoader;

namespace Entry.Global
{
    public class GameEntryPoint
    {
        private readonly DIContainer _rootContainer = new();
        private readonly AssetPathsConfig _assetPathsConfig;

        private readonly SceneNavigatorService _sceneNavigatorService;
        private readonly GameStateMachine _stateMachine;

        private readonly UILoadingView _loadingView;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStart()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            RunAsync().Forget();
        }

        private GameEntryPoint()
        {
            _assetPathsConfig = ResourceLoader.LoadOrThrow<AssetPathsConfig>("Configs/Global/AssetPathsConfig");
            var loadingViewPrefab = ResourceLoader.LoadOrThrow<UILoadingView>(_assetPathsConfig.AssetPaths.FirstOrDefault(asset => asset.Name == "UI Loading View").Path);

            _loadingView = UnityEngine.Object.Instantiate(loadingViewPrefab);

            RegisterGlobalServices();

            _sceneNavigatorService = _rootContainer.Resolve<SceneNavigatorService>();
            _stateMachine = _rootContainer.Resolve<GameStateMachine>();
        }

        private static async UniTask RunAsync()
        {
            var entryPoint = new GameEntryPoint();

            try
            {
                await entryPoint.Run();
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"GameEntry failed: {ex.GetType().Name}: {ex.Message}");
            }
        }

        private async UniTask Run()
        {
            var globalGameState = _rootContainer.Resolve<GlobalGameState>();

            await globalGameState.AsyncInitialization();
            await _stateMachine.ChangeState(_rootContainer.Resolve<StatesFactory>().CreateBootstrapState());
        }

        private void RegisterGlobalServices()
        {
            _rootContainer.RegisterInstance(_loadingView);
            _rootContainer.RegisterInstance(_assetPathsConfig);

            _rootContainer.RegisterFactory(
                sls => new SceneLoaderService(sls.Resolve<UILoadingView>())).AsSingle();
            _rootContainer.RegisterFactory(
                ggs => new GlobalGameState(_assetPathsConfig)).AsSingle();
            _rootContainer.RegisterFactory(
                gsm => new GameStateMachine()).AsSingle();
            _rootContainer.RegisterFactory(
                sns => new SceneNavigatorService(sns.Resolve<SceneLoaderService>(), _rootContainer)).AsSingle();
            _rootContainer.RegisterFactory(sf => new StatesFactory(sf.Resolve<SceneNavigatorService>(),
                sf.Resolve<GameStateMachine>(),
                _rootContainer)).AsSingle();
        }
    }
}