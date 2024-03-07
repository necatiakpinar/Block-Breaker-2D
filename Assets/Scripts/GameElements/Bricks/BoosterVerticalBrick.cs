using System.Collections.Generic;
using NecatiAkpinar.Abstractions;
using NecatiAkpinar.Data.GameElementData.Bricks;
using NecatiAkpinar.Managers;
using NecatiAkpinar.Miscs;

namespace NecatiApinar.GameElements.Bricks
{
    public class BoosterVerticalBrick : BaseDamagableBricks
    {
        private SO_BoosterVerticalBrickData _brickData;

        private void Awake()
        {
            _brickData = (SO_BoosterVerticalBrickData)Data;
            _currentHealth = _brickData.Health;
        }

        public override void Activate()
        {
            if (Tile == null)
                return;

            var verticalTiles = GridCalculatorHelper.GetVerticalTilesForSelectedTile(Tile);
            _tile.SetTileElement(null);

            List<BaseDamagableBricks> damagableTiles = new();

            for (int i = 0; i < verticalTiles.Count; i++)
            {
                var tileElement = verticalTiles[i].TileElement;
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