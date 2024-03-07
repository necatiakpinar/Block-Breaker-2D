using NecatiAkpinar.Abstractions;
using UnityEngine;

namespace NecatiAkpinar.Data.GameElementData.Bricks
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GameElementData/Bricks/NormalBrickData", fileName = "SO_NormalBrickData", order = 0)]
    public class SO_NormalBrickData : SO_BaseBrickData
    {
        [SerializeField] private int _score;
        public int Score => _score;
    }
}