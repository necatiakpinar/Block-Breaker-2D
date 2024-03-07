using System;
using NecatiAkpinar.Abstractions;
using NecatiAkpinar.Data;
using NecatiAkpinar.GameElements.Balls;

namespace NecatiAkpinar.Managers
{
    public static class EventManager
    {
        public static Action OnLevelStarted;
        public static Action<bool> OnLevelFinished;
        public static Action ResetBallPosition;
        public static Action OnBallDropped;
        public static Action<int> OnScoreUpdated;
        public static Action OnScoreUpdatedUI;
        public static Action OnBrickDestroyed;

        public static Func<BaseGameState> GetCurrentGameState;
        public static Func<SO_LevelData> GetCurrentLevel;
        public static Func<int> GetCurrentHealth;
        public static Func<int> GetCurrentScore;
        public static Func<BasePaddle> GetPaddle;
        public static Func<NormalBall> GetBall;
    }
}