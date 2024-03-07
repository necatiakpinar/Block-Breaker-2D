using NecatiAkpinar.Abstractions;
using NecatiAkpinar.Data.PersistentData;
using NecatiAkpinar.Managers;
using NecatiAkpinar.Miscs;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NecatiAkpinar.UI.Widgets
{
    public class GameplayTopBarWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentLevelLabel;
        [SerializeField] private TMP_Text _nextLevelLabel;
        [SerializeField] private TMP_Text _currentHealth;
        [SerializeField] private Slider _progressSlider;
        [Header("Buttons")] 
        [SerializeField] private BaseButton _retryButton;

        private float _progressBarStartingValue = 0.0f;
        private float _progressBarEndingValue;

        private GameplayData _gameplayData;
        private int _currentDestroyedBrickAmount = 0;

        private void OnEnable()
        {
            EventManager.OnBrickDestroyed += UpdateProgressBar;
            EventManager.OnBallDropped += UpdateHealthLabel;
        }

        private void OnDestroy()
        {
            EventManager.OnBrickDestroyed -= UpdateProgressBar;
            EventManager.OnBallDropped -= UpdateHealthLabel;
        }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _gameplayData = GameDataState.GameplayData;

            _currentLevelLabel.text = (_gameplayData.CurrentLevelIndex + 1).ToString();
            _nextLevelLabel.text = (_gameplayData.CurrentLevelIndex + 2).ToString();
            UpdateHealthLabel();

            var gridSize = EventManager.GetCurrentLevel().GridSize;
            _progressSlider.minValue = 0;
            _progressSlider.maxValue = gridSize.x * gridSize.y;
            
            _retryButton.Init(OnRetryButtonClicked);
        }

        private void UpdateProgressBar()
        {
            _currentDestroyedBrickAmount++;
            _progressSlider.value = _currentDestroyedBrickAmount;
        }

        private void UpdateHealthLabel()
        {
            _currentHealth.text = $"Remaining Health {EventManager.GetCurrentHealth()}";
        }
        private void OnRetryButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}