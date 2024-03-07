using UnityEngine;

namespace NecatiAkpinar.Data
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GameElementData/TileMonoData", fileName = "SO_TileMonoData", order = 2)]
    public class SO_TileMonoData : ScriptableObject
    {
        [SerializeField] private float _tileElementDropSpeed = 0.05f;

        public float TileElementDropSpeed => _tileElementDropSpeed;
    }
}