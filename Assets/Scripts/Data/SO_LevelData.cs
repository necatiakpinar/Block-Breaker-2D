using System;
using System.Collections.Generic;
using NecatiAkpinar.Misc;
using UnityEngine;

namespace NecatiAkpinar.Data
{
    [Serializable]
    public class GameElementSpawnSettings
    {
        [SerializeField] private GameElementType _elementType;
        [Range(0, 100f)] [SerializeField] private float _spawnRatio;

        public GameElementType ElementType => _elementType;
        public float SpawnRatio => _spawnRatio;
    }

    [CreateAssetMenu(menuName = "ScriptableObjects/LevelData", fileName = "SO_LevelData_", order = 1)]
    public class SO_LevelData : ScriptableObject
    {
        [SerializeField] private int _levelIndex;
        [SerializeField] private List<GameElementSpawnSettings> _spawnableElements;
        [SerializeField] private Vector2Int _gridSize;

        public int LevelIndex => _levelIndex;
        public Vector2Int GridSize => _gridSize;
        public List<GameElementSpawnSettings> SpawnableElements => _spawnableElements;
    }
}