using Core.Service;
using System.Collections.Generic;
using UnityEngine;

namespace SO.Global
{
    [CreateAssetMenu(menuName = "Configs/Global/Asset Database By Type", fileName = "Asset Database By Type")]
    public class AssetDatabaseByType : ScriptableObject
    {
        [field: SerializeField] public AssetType AssetType { get; private set; }
        [field: SerializeField] public List<AssetEntry> AssetEntry { get; private set; } = new();
    }
}