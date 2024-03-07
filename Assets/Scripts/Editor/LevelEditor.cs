using NecatiAkpinar.Data.PersistentData;
using UnityEngine;
using UnityEditor;

namespace NecatiAkpinar.Editor
{
    public class LevelEditor : EditorWindow
    {
        private readonly string _resetGameDataButton = "Reset Game Data";
        private readonly string _changeCurrentLevelIndexButton = "Update Level";
        private readonly string _changedScoreButton = "Update Score";

        private int updatedCurrentLevelValue = 0;
        private int updatedScoreValue = 0;

        private GUIStyle centeredStyle;

        [MenuItem("NecatiAkpinar/Level Editor")]
        public static void ShowWindow()
        {
            GetWindow<LevelEditor>("Level Editor");
        }

        private void OnGUI()
        {
            centeredStyle = new GUIStyle(GUI.skin.label)
            {
                alignment = TextAnchor.MiddleCenter,
                fontStyle = FontStyle.Bold
            };

            GUILayout.BeginVertical();
            EditorGUILayout.LabelField("Reset", centeredStyle, GUILayout.ExpandWidth(true));
            if (GUILayout.Button(_resetGameDataButton))
                ResetGameData();

            GUILayout.Space(10);

            EditorGUILayout.LabelField("Level Settings", centeredStyle, GUILayout.ExpandWidth(true));

            GUILayout.BeginHorizontal();
            updatedCurrentLevelValue = EditorGUILayout.IntField("Update Current Level = ", updatedCurrentLevelValue);
            if (GUILayout.Button(_changeCurrentLevelIndexButton))
                UpdateCurrentLevel();

            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            //EditorGUILayout.LabelField("", centeredStyle, GUILayout.ExpandWidth(true));

            GUILayout.BeginVertical();
            updatedScoreValue = EditorGUILayout.IntField("Total Score= ", updatedScoreValue);
            if (GUILayout.Button(_changedScoreButton))
                UpdateTotalScore();

            GUILayout.Space(10);

            GUILayout.EndVertical();

            GUILayout.EndVertical();
        }

        private void ResetGameData()
        {
            GameDataState.ResetData();
        }

        private void UpdateCurrentLevel()
        {
            GameDataState.LoadSaveDataFromDisk();
            GameDataState.GameplayData.ChangeCurrentLevelIndex(updatedCurrentLevelValue);
            GameDataState.SaveDataToDisk();
        }

        private void UpdateEnemyKilledAmount()
        {
            GameDataState.LoadSaveDataFromDisk();
            GameDataState.SaveDataToDisk();
        }

        private void UpdateTotalScore()
        {
            GameDataState.LoadSaveDataFromDisk();
            GameDataState.GameplayData.ChangeTotalScore(updatedScoreValue);
            GameDataState.SaveDataToDisk();
        }
    }
}