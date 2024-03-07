using System.Collections.Generic;
using NecatiAkpinar.Abstractions;
using NecatiAkpinar.Data.GameElementData.Bricks;
using NecatiAkpinar.Managers;

namespace NecatiApinar.GameElements.Bricks
{
    public class BoosterNeighbourBrick : BaseDamagableBricks
    {
        private SO_BoosterNeighbourBrickData _brickData;

        private void Awake()
        {
            _brickData = (SO_BoosterNeighbourBrickData)Data;
            _currentHealth = _brickData.Health;
        }

        public override void Activate()
        {
            if (Tile == null)
                return;

            _tile.SetTileElement(null);

            List<BaseDamagableBricks> damagableTiles = new();

            foreach (TileMono tile in Tile.Neighbours.Values)
            {
                var tileElement = tile.TileElement;
                if (tileElement != null && tileElement.GetComponent<BaseDamagableBricks>() != null)
                {
                    var damagableElement = tileElement.GetComponent<BaseDamagableBricks>();
                    damagableTiles.Add(damagableElement);
                }
            }

            var collectedScore = _brickData.DamagePower + (damagableTiles.Count * _brickData.DamagePower);
            EventManager.OnScoreUpdated(collectedScore);

            for (int i = 0; i < damagableTiles.Count; i++)
            {
                var damagableElement = damagableTiles[i];
                damagableElement.TakeDamage(_brickData.DamagePower);
            }

            ReturnToPool();
        }
    }
}