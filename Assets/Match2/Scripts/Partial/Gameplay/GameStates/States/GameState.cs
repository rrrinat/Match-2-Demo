using Match2.Common.StateMachine;

namespace Match2.Partial.Gameplay.GameStates.States
{
    public abstract class GameState : IState
    {
        protected readonly  GameStateMachine gameStateMachine;
        protected GameStateMachine GameStateMachine => gameStateMachine;
        protected GameState(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}
