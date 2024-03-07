using System.Collections.Generic;
using NecatiApinar.GameElements;

namespace NecatiAkpinar.Miscs
{
    public static class GridCalculatorHelper
    {
        public static List<TileMono> GetVerticalTilesForSelectedTile(TileMono boosterTile)
        {
            TileMono[,] _tiles = GameReferences.Instance.GridController.Tiles;
            TileMono matchedTile;
            List<TileMono> resultTiles = new List<TileMono>();

            int selectedTileX = boosterTile.Coordinates.x;
            int selectedTileY = boosterTile.Coordinates.y;

            for (int i = 0; i < _tiles.GetLength(1); i++)
            {
                if (i == selectedTileY)
                    continue;

                matchedTile = _tiles[selectedTileX, i];
                resultTiles.Add(matchedTile);
            }

            return resultTiles;
        }

        public static List<TileMono> GetHorizontalTilesForSelectedTile(TileMono boosterTile)
        {
            TileMono[,] _tiles = GameReferences.Instance.GridController.Tiles;
            TileMono matchedTile;
            List<TileMono> resultTiles = new List<TileMono>();

            int selectedTileX = boosterTile.Coordinates.x;
            int selectedTileY = boosterTile.Coordinates.y;

            for (int i = 0; i < _tiles.GetLength(0); i++)
            {
                if (i == selectedTileX)
                    continue;

                matchedTile = _tiles[i, selectedTileY];
                resultTiles.Add(matchedTile);
            }

            return resultTiles;
        }
    }
}