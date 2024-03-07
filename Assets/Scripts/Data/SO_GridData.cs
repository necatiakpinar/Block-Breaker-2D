using NecatiApinar.GameElements;
using UnityEngine;

namespace NecatiAkpinar.Data
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GridData", fileName = "SO_GridData", order = 1)]
    public class SO_GridData : ScriptableObject
    {
        [Header("Tile Prefab")] [SerializeField]
        private TileMono _tilePrefab;

        public TileMono TilePrefab => _tilePrefab;
    }
}