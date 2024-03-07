using UnityEngine;

namespace NecatiAkpinar.Abstractions
{
    public abstract class SO_BasePaddleData : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;

        public float MovementSpeed => _movementSpeed;
    }
}