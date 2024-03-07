using System;
using NecatiAkpinar.Abstractions;
using NecatiAkpinar.Controllers;
using NecatiAkpinar.Data.PersistentData;
using NecatiAkpinar.GameStates;
using NecatiAkpinar.Misc;
using NecatiAkpinar.Miscs;
using UnityEngine;

namespace NecatiAkpinar.Managers
{
    public class GameManager : MonoBehaviour
    {
        private StartingState _startingState;
        private InGameState _inGameState;
        private LevelEndState _levelEndState;

        private BaseGameState _currentState;

        public BaseGameState CurrentState => _currentState;

        private void OnEnable()
        {
            EventManager.GetCurrentGameState += (() => _currentState);
        }

        private void OnDisable()
        {
            EventManager.GetCurrentGameState -= (() => _currentState);
        }

        private void Awake()
        {
            Application.targetFrameRate = 60;
            GameDataState.LoadSaveDataFromDisk();
        }

        private void Start()
        {
            GridController gridController = GameReferences.Instance.GridController;

            _startingState = new StartingState(ChangeGameState, gridController);
            _inGameState = new InGameState(ChangeGameState);
            _levelEndState = new LevelEndState(ChangeGameState);

            GameStateInfoTransporter infoTransporter = new GameStateInfoTransporter();
            ChangeGameState(GameStateType.Starting, infoTransporter);
        }

        private void ChangeGameState(GameStateType stateType, GameStateInfoTransporter _infoTransporter)
        {
            switch (stateType)
            {
                case GameStateType.Starting:
                    _currentState = _startingState;
                    break;
                case GameStateType.InGame:
                    _currentState = _inGameState;
                    break;
                case GameStateType.LevelEnd:
                    _currentState = _levelEndState;
                    break;
            }

            _currentState.Start(_infoTransporter);
        }
    }
}