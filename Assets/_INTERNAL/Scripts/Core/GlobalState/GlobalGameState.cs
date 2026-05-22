using Cysharp.Threading.Tasks;
using SO.Global;

namespace Core.GlobalState
{
    public class GlobalGameState
    {
        private readonly AssetDatabase _assetDatabase;

        public AssetDatabase AssetDatabase => _assetDatabase;

        public GlobalGameState(AssetDatabase assetDatabase)
        {
            _assetDatabase = assetDatabase;
        }

        public async UniTask AsyncInitialization()
        {

        }

        public void Dispose()
        {

        }
    }
}