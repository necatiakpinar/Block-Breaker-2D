using System.Collections.Generic;
using NecatiAkpinar.Abstractions;
using NecatiAkpinar.Data.GameElementData.Bricks;
using NecatiAkpinar.Managers;
using NecatiAkpinar.Miscs;

namespace NecatiApinar.GameElements.Bricks
{
    public class BoosterHorizontalBrick : BaseDamagableBricks
    {
        private SO_BoosterHorizontalBrickData _brickData;

        private void Awake()
        {
            _brickData = (SO_BoosterHorizontalBrickData)Data;
        }

        public override void Activate()
        {
            if (Tile == null)
                return;

            var horizontalTiles = GridCalculatorHelper.GetHorizontalTilesForSelectedTile(Tile);
            _tile.SetTileElement(null);

            List<BaseDamagableBricks> damagableTiles = new();

            for (int i = 0; i < horizontalTiles.Count; i++)
            {
                var tileElement = horizontalTiles[i].TileElement;
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