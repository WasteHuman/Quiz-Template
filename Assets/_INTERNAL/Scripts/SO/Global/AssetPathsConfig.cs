using Core.Service;
using System.Collections.Generic;
using UnityEngine;

namespace SO.Global
{
    [CreateAssetMenu(menuName = "Configs/Global/Asset Paths Config", fileName = "AssetPathsConfig")]
    public class AssetPathsConfig : ScriptableObject
    {
        [field: SerializeField] public List<AssetPath> AssetPaths { get; private set; } = new();
    }
}