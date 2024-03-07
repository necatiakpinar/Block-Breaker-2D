using System;
using System.Collections.Generic;
using NecatiAkpinar.Abstractions;
using NecatiAkpinar.Data;
using NecatiAkpinar.Data.PersistentData;
using NecatiAkpinar.Managers;
using NecatiAkpinar.Misc;
using NecatiApinar.GameElements;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NecatiAkpinar.Controllers
{
    public class GridController
    {
        private SO_TileMonoData _tileMonoData;
        private SO_GridData _soGridData;
        private SO_LevelDataContainer _soLevelDataContainer;

        private SO_LevelData _currentLevelData;

        private int _currentRow, _currentColumn;

        public TileMono[,] Tiles { get; private set; }

        public Dictionary<Vector2Int, TileMono> TilesDict { get; private set; }

        private Dictionary<TileDirectionType, Vector2Int> _tileDirectionCoordinates = new()
        {
            { TileDirectionType.Up, new Vector2Int(0, 1) },
            { TileDirectionType.UpRight, new Vector2Int(1, 1) },
            { TileDirectionType.Right, new Vector2Int(1, 0) },
            { TileDirectionType.DownRight, new Vector2Int(1, -1) },
            { TileDirectionType.Down, new Vector2Int(0, -1) },
            { TileDirectionType.DownLeft, new Vector2Int(-1, -1) },
            { TileDirectionType.Left, new Vector2Int(-1, 0) },
            { TileDirectionType.UpLeft, new Vector2Int(-1, 1) },
        };

        public GridController(SO_LevelDataContainer levelContainer, SO_TileMonoData tileMonoData, SO_GridData gridData)
        {
            _tileMonoData = tileMonoData;
            _soGridData = gridData;
            var currentLevel = GameDataState.GameplayData.CurrentLevelIndex;
            _currentLevelData = levelContainer.AllLevels[currentLevel];

            Tiles = new TileMono[_currentLevelData.GridSize.x, _currentLevelData.GridSize.y];
            TilesDict = new Dictionary<Vector2Int, TileMono>();
        }

        public void CreateGrid()
        {
            if (_currentLevelData == null)
                Debug.LogError("Level data could not be loaded");

            GameElementType spawnableElement;
            for (int i = 0; i < _currentLevelData.SpawnableElements.Count; i++)
            {
                spawnableElement = _currentLevelData.SpawnableElements[i].ElementType;
            }

            TileMono tile;
            BaseTileElement tileElement;
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                for (int x = 0; x < Tiles.GetLength(0); x++)
                {
                    tile = GameObject.Instantiate(_soGridData.TilePrefab);
                    tile.Init(_tileMonoData, x, y);

                    Tiles[x, y] = tile;
                    TilesDict.Add(new Vector2Int(x, y), tile);

                    tileElement = CreateAllowedGridElement(tile, y);
                    tile.SetTileElement(tileElement);
                }
            }

            CalculateTileNeighbours();
        }

        public void CalculateTileNeighbours()
        {
            Dictionary<TileDirectionType, TileMono> neighbours;
            Vector2Int possibleNeighbourCoordinates;
            int directionCount = Enum.GetValues(typeof(TileDirectionType)).Length;

            foreach (TileMono tile in TilesDict.Values)
            {
                neighbours = new Dictionary<TileDirectionType, TileMono>();

                for (int i = 0; i < directionCount; i++)
                {
                    possibleNeighbourCoordinates = tile.Coordinates + _tileDirectionCoordinates[(TileDirectionType)i];
                    if (TilesDict.TryGetValue(possibleNeighbourCoordinates, out var neighbour))
                        neighbours.Add((TileDirectionType)i, neighbour);

                    tile.SetNeighbours(neighbours);
                }
            }
        }

        public BaseTileElement CreateAllowedGridElement(TileMono parent, int tileHeight = -1)
        {
            GameElementType spawnableElementType = ChooseSpawnableElementType();

            if (spawnableElementType != GameElementType.None)
                return CreateTileElement(parent, spawnableElementType);

            return null;
        }

        public GameElementType ChooseSpawnableElementType()
        {
            float total = 0;
            foreach (var spawnableElement in _currentLevelData.SpawnableElements)
                total += spawnableElement.SpawnRatio;

            float random = Random.Range(0, total);
            foreach (var spawnableElement in _currentLevelData.SpawnableElements)
            {
                if (random < spawnableElement.SpawnRatio)
                    return spawnableElement.ElementType;

                random -= spawnableElement.SpawnRatio;
            }

            return GameElementType.None;
        }

        public BaseTileElement CreateTileElement(TileMono tile, GameElementType elementType)
        {
            BaseTileElement tileElement = TileElementPoolManager.Instance.SpawnFromPool(elementType, Vector3.zero, Quaternion.identity);
            tileElement.transform.parent = tile.transform;
            tileElement.transform.localPosition = Vector3.zero;
            tileElement.gameObject.SetActive(true);
            return tileElement;
        }

        public bool IsAllBricksExploded()
        {
            foreach (TileMono tile in TilesDict.Values)
                if (tile.TileElement != null)
                    return false;

            return true;
        }
    }
}