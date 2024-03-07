using NecatiAkpinar.Abstractions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NecatiAkpinar.UI.Windows
{
    public class LevelEndWindow : BaseWindow
    {
        [SerializeField] private TMP_Text titleLabel;
        [SerializeField] private BaseButton _nextLevelButton;
        [SerializeField] private BaseButton _retryButton;

        private readonly string _levelFinishedText = "Level Finished";
        private readonly string _levelFailedText = "Level Failed";

        private readonly Color _levelFinishedTitleColor = Color.green;
        private readonly Color _levelFailedTitleColor = Color.red;

        
        public void Init(bool isPlayerWon)
        {
            _nextLevelButton.Init(LoadGameplayScene);
            _retryButton.Init(LoadGameplayScene);
            
            if (isPlayerWon)
                WinScreen();
            else
                LoseScreen();
        }

        private void WinScreen()
        {
            _nextLevelButton.gameObject.SetActive(true);
            _retryButton.gameObject.SetActive(false);
            titleLabel.text = _levelFinishedText;
            titleLabel.color = _levelFinishedTitleColor;
        }

        private void LoseScreen()
        {
            _retryButton.gameObject.SetActive(true);
            _nextLevelButton.gameObject.SetActive(false);
            titleLabel.text = _levelFailedText;
            titleLabel.color = _levelFailedTitleColor;
        }

        private void LoadGameplayScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}