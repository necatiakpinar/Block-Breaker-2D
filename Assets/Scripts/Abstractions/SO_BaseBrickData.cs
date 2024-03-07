using UnityEngine;

namespace NecatiAkpinar.Abstractions
{
    public abstract class SO_BaseBrickData : ScriptableObject
    {
        [SerializeField] private float _health;

        public float Health => _health;
    }
}