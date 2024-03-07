using System;
using NecatiAkpinar.Abstractions;
using NecatiAkpinar.Controllers;
using NecatiAkpinar.Managers;
using NecatiAkpinar.Misc;
using UnityEngine;

namespace NecatiAkpinar.GameStates
{
    public class StartingState : BaseGameState
    {
        private Action<GameStateType, GameStateInfoTransporter> _changeStateCallback;
        private GridController _gridController;

        public StartingState(Action<GameStateType, GameStateInfoTransporter> changeStateCallback, GridController gridController)
        {
            _changeStateCallback = changeStateCallback;
            _gridController = gridController;
            SubscribeEvents();
        }

        public void SubscribeEvents()
        {
            EventManager.OnLevelStarted += End;
        }

        public void UnsubscribeEvents()
        {
            EventManager.OnLevelStarted -= End;
        }

        public override void Start(GameStateInfoTransporter stateInfoTransporter)
        {
            _gridController.CreateGrid();
        }

        public override void End()
        {
            UnsubscribeEvents();
            GameStateInfoTransporter infoTransporter = new GameStateInfoTransporter();
            _changeStateCallback?.Invoke(GameStateType.InGame, infoTransporter);
        }
    }
}