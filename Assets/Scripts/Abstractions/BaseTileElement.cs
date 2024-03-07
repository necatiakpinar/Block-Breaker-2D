using NecatiAkpinar.Managers;
using NecatiAkpinar.Misc;
using NecatiApinar.GameElements;
using UnityEngine;

namespace NecatiAkpinar.Abstractions
{
    public abstract class BaseTileElement : MonoBehaviour
    {
        [SerializeField] private GameElementType _elementType;
        protected TileMono _tile;
        public GameElementType ElementType => _elementType;

        [SerializeField] protected SpriteRenderer _spriteRenderer;
        public TileMono Tile => _tile;

        public void Init(TileMono tile)
        {
            _tile = tile;
            transform.parent = tile.transform;
        }

        public virtual void Reset()
        {
            transform.parent = null;
            gameObject.SetActive(false);
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }

        public virtual void ReturnToPool()
        {
            _tile = null;
            TileElementPoolManager.Instance.ReturnToPool(ElementType, this);
        }
    }
}