using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using NecatiAkpinar.Addressables;
using NecatiAkpinar.Data;
using NecatiAkpinar.Data.PersistentData;
using NecatiAkpinar.Misc;
using NecatiAkpinar.Miscs;
using UnityEngine;

namespace NecatiAkpinar.Managers
{
    public class LevelManager : MonoBehaviour
    {
        private SO_LevelDataContainer _levels;

        private SO_LevelData _currentLevel;
        private int _currentLevelIndex;
        private bool _isLevelFinished;
        private int _currentHealth;
        private int _currentScore;
        private int _currentDestroyedBrick;

        private void OnEnable()
        {
            EventManager.OnLevelFinished += OnLevelFinished;
            EventManager.OnBallDropped += DecreaseHealth;
            EventManager.OnScoreUpdated += UpdateScore;
            EventManager.OnBrickDestroyed += OnBrickDestroyed;
            
            EventManager.GetCurrentLevel += (() => _currentLevel);
            EventManager.GetCurrentHealth += (() => _currentHealth);
            EventManager.GetCurrentScore += (() => _currentScore);
        }

        private void OnDisable()
        {
            EventManager.OnLevelFinished -= OnLevelFinished;
            EventManager.OnBallDropped -= DecreaseHealth;
            EventManager.OnScoreUpdated -= UpdateScore;
            EventManager.OnBrickDestroyed -= OnBrickDestroyed;
            
            EventManager.GetCurrentLevel -= (() => _currentLevel);
            EventManager.GetCurrentHealth -= (() => _currentHealth);
            EventManager.GetCurrentScore -= (() => _currentScore);
        }

        private void Start()
        {
            _currentLevelIndex = GameDataState.GameplayData.CurrentLevelIndex;
            _isLevelFinished = false;

            _levels = DataManager.Instance.LevelContainer;
            
            if (_levels.AllLevels == null)
                return;

            if (_levels.AllLevels.Count <= _currentLevelIndex)
            {
                GameDataState.GameplayData.ChangeCurrentLevelIndex(0);
                _currentLevelIndex = GameDataState.GameplayData.CurrentLevelIndex;
            }

            _currentLevel = _levels.AllLevels[_currentLevelIndex];
            _currentHealth = GameDataState.GameplayData.PlayerHealth;
            _currentScore = 0;
            _currentDestroyedBrick = 0;
        }

        private void OnLevelFinished(bool isWin)
        {
            _isLevelFinished = true;

            if (isWin)
            {
                GameDataState.GameplayData.IncreaseLevel();
                GameDataState.GameplayData.IncreaseTotalScore(_currentScore);
                GameDataState.SaveDataToDisk();
            }
        }

        private void OnBrickDestroyed()
        {
            var totalBricksOfLevel = _currentLevel.GridSize.x * _currentLevel.GridSize.y;
            _currentDestroyedBrick++;
            if (_currentDestroyedBrick >= totalBricksOfLevel)
                EventManager.OnLevelFinished(true);

        }
        private void DecreaseHealth()
        {
            _currentHealth--;
            if (_currentHealth == 0)
                EventManager.OnLevelFinished?.Invoke(false);
            else
                EventManager.ResetBallPosition?.Invoke();
            
        }
        
        private void UpdateScore(int collectedScore)
        {
            _currentScore += collectedScore;
            EventManager.OnScoreUpdatedUI?.Invoke();
        }
    }
}

