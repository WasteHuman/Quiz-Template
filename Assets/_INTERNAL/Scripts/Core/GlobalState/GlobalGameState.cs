using Cysharp.Threading.Tasks;
using SO.Global;

namespace Core.GlobalState
{
    public class GlobalGameState
    {
        private readonly AssetPathsConfig _assetPaths;

        public AssetPathsConfig AssetPaths => _assetPaths;

        public GlobalGameState(AssetPathsConfig assetPaths)
        {
            _assetPaths = assetPaths;
        }

        public async UniTask AsyncInitialization()
        {

        }

        public void Dispose()
        {

        }
    }
}