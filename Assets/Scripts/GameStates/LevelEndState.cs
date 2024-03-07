using System;
using NecatiAkpinar.Abstractions;
using NecatiAkpinar.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NecatiAkpinar.GameStates
{
    public class LevelEndState : BaseGameState
    {
        private Action<GameStateType, GameStateInfoTransporter> _changeStateCallback;

        public LevelEndState(Action<GameStateType, GameStateInfoTransporter> changeStateCallback)
        {
            _changeStateCallback = changeStateCallback;
        }

        public override void Start(GameStateInfoTransporter stateInfoTransporter)
        {
            if (stateInfoTransporter.IsLevelWin)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public override void End()
        {
        }
    }
}