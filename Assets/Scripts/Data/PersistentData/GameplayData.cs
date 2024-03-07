using System;
using UnityEngine;

namespace NecatiAkpinar.Data.PersistentData
{
    [Serializable]
    public class GameplayData
    {
        [SerializeField] private int _currentLevelIndex;
        [SerializeField] private float _totalScore;

        private const int _levelIncreaser = 1;
        private const int _playerHealth = 3;

        public int CurrentLevelIndex => _currentLevelIndex;
        public float TotalScore => _totalScore;
        public int PlayerHealth => _playerHealth;

        public void IncreaseLevel()
        {
            _currentLevelIndex += _levelIncreaser;
        }

        public void ChangeCurrentLevelIndex(int newLevelIndex)
        {
            _currentLevelIndex = newLevelIndex;
        }

        public void IncreaseTotalScore(int increaseAmount)
        {
            _totalScore += increaseAmount;
        }

        public void ChangeTotalScore(int newTotalScore)
        {
            _totalScore = newTotalScore;
        }
        
    }
}