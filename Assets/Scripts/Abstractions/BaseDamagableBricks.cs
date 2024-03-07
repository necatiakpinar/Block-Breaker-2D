using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using NecatiAkpinar.Addressables;
using NecatiAkpinar.Controllers;
using NecatiAkpinar.GameStates.Interfaces;
using NecatiAkpinar.Managers;
using NecatiAkpinar.Misc;
using NecatiAkpinar.Miscs;
using UnityEngine;
using UnityEngine.U2D;

namespace NecatiAkpinar.Abstractions
{
    public abstract class BaseDamagableBricks : BaseBrick, IDamagable
    {
        protected float _currentHealth;
        private BrickDamageType _currentDamageType = BrickDamageType.Solid;

        private readonly string _brickAssetKey = "brick_"; //This can be moved into child classes for spesific assets
        private SpriteAtlas _brickSpriteAtlas;

        private Dictionary<BrickDamageType, Vector2> _damageTypeToRatio = new()
        {
            { BrickDamageType.Solid, new Vector2(1.0f, 0.7f) },
            { BrickDamageType.Damaged, new Vector2(0.7f, 0.4f) },
            { BrickDamageType.HighlyDamaged, new Vector2(0.4f, 0.0f) },
        };

        private void Awake()
        {
            _currentHealth = Data.Health;
        }

        private void Start()
        {
            _brickSpriteAtlas = DataManager.Instance.BrickSpriteAtlas;
            var spriteName = _brickAssetKey + _currentDamageType.ToString();
            SetSprite(spriteName);
        }

        public virtual void SetSprite(string spriteName)
        {
            var brickSprite = _brickSpriteAtlas.GetSprite(spriteName);
            _spriteRenderer.sprite = brickSprite;
        }

        public virtual void TakeDamage(float damageAmount)
        {
            if (Tile == null)
                return;

            _currentHealth = _currentHealth = Mathf.Max(0, _currentHealth - damageAmount);

            GFXManager.Instance.PlayVFX(Constants.VFX_BasicHitParticle, transform.position, Quaternion.identity);

            var currentHealthRatio = _currentHealth / Data.Health;

            while (!(currentHealthRatio <= _damageTypeToRatio[_currentDamageType].x && currentHealthRatio >= _damageTypeToRatio[_currentDamageType].y))
            {
                if ((int)_currentDamageType < _damageTypeToRatio.Count - 1)
                    _currentDamageType++;

                var spriteName = _brickAssetKey + _currentDamageType.ToString();
                SetSprite(spriteName);
            }

            if (_currentHealth == 0)
            {
                Activate();
                EventManager.OnBrickDestroyed?.Invoke();
                GFXManager.Instance.PlaySFX(Constants.SFX_ExplosionBrick);
            }
        }
    }
}