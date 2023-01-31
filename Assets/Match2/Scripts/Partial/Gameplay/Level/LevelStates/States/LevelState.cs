using Match2.Common.StateMachine;

namespace Match2.Partial.Gameplay.Level.LevelStates.States
{
    public abstract class LevelState : IState
    {
        protected readonly  LevelStateMachine levelStateMachine;
        
        protected LevelStateMachine LevelStateMachine => levelStateMachine;
        protected LevelState(LevelStateMachine levelStateMachine)
        {
            this.levelStateMachine = levelStateMachine;
        }
        
        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}