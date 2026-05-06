using Core.Service;
using System.Collections.Generic;
using UnityEngine;

namespace SO.Global
{
    [CreateAssetMenu(menuName = "Configs/Global/Assets Paths Config", fileName = "AssetsPathsConfig")]
    public class AssetsPathsConfig : ScriptableObject
    {
        [field: SerializeField] public List<AssetPath> AssetPaths { get; private set; } = new();
    }
}