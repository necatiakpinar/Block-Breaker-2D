using NecatiAkpinar.Abstractions;
using UnityEngine;

namespace NecatiAkpinar.Data.GameElementData.Bricks
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GameElementData/Bricks/BoosterNeighbourBrickData", fileName = "SO_BoosterNeighbourBrickData", order = 3)]
    public class SO_BoosterNeighbourBrickData : SO_BaseBrickData
    {
        [SerializeField] private int _damagePower;

        public int DamagePower => _damagePower;
    }
}