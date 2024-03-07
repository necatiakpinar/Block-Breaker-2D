using UnityEngine;

namespace NecatiAkpinar.Abstractions
{
    public abstract class SO_BaseBallData : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _damagePower;
        [SerializeField] private Vector2 _startingForceXRange;
        public float MovementSpeed => _movementSpeed;
        public float DamagePower => _damagePower;
        public Vector2 StartingForceXRange => _startingForceXRange;
    }
}