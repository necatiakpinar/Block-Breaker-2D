using NecatiAkpinar.Abstractions;
using UnityEngine;

namespace NecatiAkpinar.Data.GameElementData.Bricks
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GameElementData/Bricks/BoosterVerticalBrickData", fileName = "SO_BoosterVerticalBrickData", order = 2)]
    public class SO_BoosterVerticalBrickData : SO_BaseBrickData
    {
        [SerializeField] private int _damagePower;

        public int DamagePower => _damagePower;
    }
}