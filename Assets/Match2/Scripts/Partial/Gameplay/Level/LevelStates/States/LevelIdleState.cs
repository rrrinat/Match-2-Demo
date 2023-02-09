using Match2.Partial.Gameplay.Factories;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level.LevelStates.States
{
    public class LevelIdleState : LevelState
    {
        private IFieldFactory fieldFactory;

        public LevelIdleState(LevelStateMachine levelStateMachine, IFieldFactory fieldFactory) : base(levelStateMachine)
        {
            this.fieldFactory = fieldFactory;
        }

        public override void Enter()
        {
            levelStateMachine.SetState<LevelSpawnState>();
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}