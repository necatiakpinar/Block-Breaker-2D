using NecatiAkpinar.Data.PersistentData;
using NecatiAkpinar.Managers;
using TMPro;
using UnityEngine;

namespace NecatiAkpinar.UI.Widgets
{
    public class ScoreWidget : MonoBehaviour
    {
        [SerializeField] protected TMP_Text _totalScore;
        [SerializeField] protected TMP_Text _currentScore;


        private void OnEnable()
        {
            EventManager.OnScoreUpdatedUI += UpdateCurrentScore;
        }

        private void OnDisable()
        {
            EventManager.OnScoreUpdatedUI -= UpdateCurrentScore;
        }

        private void Start()
        {
            _totalScore.text = $"Total Score {GameDataState.GameplayData.TotalScore}";
            UpdateCurrentScore();
        }

        private void UpdateCurrentScore()
        {
            _currentScore.text = $"Current Score {EventManager.GetCurrentScore()}";
        }
    }
}