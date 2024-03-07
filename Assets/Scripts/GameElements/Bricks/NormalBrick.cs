using System;
using NecatiAkpinar.Abstractions;
using NecatiAkpinar.Data.GameElementData.Bricks;
using NecatiAkpinar.Managers;

namespace NecatiApinar.GameElements.Bricks
{
    public class NormalBrick : BaseDamagableBricks
    {
        private SO_NormalBrickData _brickData;

        private void Awake()
        {
            _brickData = (SO_NormalBrickData)Data;
            _currentHealth = _brickData.Health;
        }

        
        public override void Activate()
        {
            EventManager.OnScoreUpdated(_brickData.Score);
            ReturnToPool();
        }
     
    }
}