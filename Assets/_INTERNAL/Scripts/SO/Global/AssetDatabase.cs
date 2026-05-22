using System.Collections.Generic;
using UnityEngine;

namespace SO.Global
{
    [CreateAssetMenu(fileName = "AssetDatabase", menuName = "Configs/Global/Asset Database")]
    public class AssetDatabase : ScriptableObject
    {
        [field: SerializeField] public List<AssetDatabaseByType> Assets { get; private set; } = new();
    }
}