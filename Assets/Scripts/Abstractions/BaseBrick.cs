using UnityEngine;

namespace NecatiAkpinar.Abstractions
{
    public abstract class BaseBrick : BaseTileElement
    {
        [SerializeField] private SO_BaseBrickData _data;

        public SO_BaseBrickData Data => _data;

        public abstract void Activate();
    }
}