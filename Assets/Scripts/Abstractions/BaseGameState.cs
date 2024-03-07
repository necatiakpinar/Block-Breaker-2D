using NecatiAkpinar.GameStates;

namespace NecatiAkpinar.Abstractions
{
    public abstract class BaseGameState
    {
        public abstract void Start(GameStateInfoTransporter stateInfoTransporter);
        public abstract void End();
    }
}