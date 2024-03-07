using NecatiAkpinar.Abstractions;
using UnityEngine;

namespace NecatiAkpinar.Data.GameElementData.Bricks
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GameElementData/Bricks/BoosterHorizontalBrick", fileName = "SO_BoosterHorizontalBrick", order = 1)]
    public class SO_BoosterHorizontalBrickData : SO_BaseBrickData
    {
        [SerializeField] private int _damagePower;

        public int DamagePower => _damagePower;
    }
}