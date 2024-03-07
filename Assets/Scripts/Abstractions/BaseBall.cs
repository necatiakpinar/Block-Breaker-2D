using NecatiAkpinar.Controllers;
using NecatiAkpinar.GameStates.Interfaces;
using NecatiAkpinar.Managers;
using NecatiAkpinar.Misc;
using NecatiAkpinar.Miscs;
using UnityEngine;

namespace NecatiAkpinar.Abstractions
{
    public abstract class BaseBall : MonoBehaviour
    {
        [SerializeField] private SO_BaseBallData _data;
        public SO_BaseBallData Data => _data;

        private GridController _gridController;

        private void Start()
        {
            _gridController = GameReferences.Instance.GridController;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_gridController == null)
                _gridController = GameReferences.Instance.GridController;

            IDamagable brick = other.collider.GetComponent<IDamagable>();
            if (brick != null)
            {
                GFXManager.Instance.PlaySFX(Constants.SFX_BallHitBrick);
                brick.TakeDamage(_data.DamagePower);
                if (_gridController.IsAllBricksExploded())
                    EventManager.OnLevelFinished?.Invoke(true);
            }
        }
    }
}