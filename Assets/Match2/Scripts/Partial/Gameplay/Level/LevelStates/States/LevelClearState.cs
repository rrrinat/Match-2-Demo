using Match2.Partial.Gameplay.Factories;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level.LevelStates.States
{
    public class LevelClearState : LevelState
    {
        private IFieldFactory fieldFactory;
        
        public LevelClearState(LevelStateMachine levelStateMachine, IFieldFactory fieldFactory) : base(levelStateMachine)
        {
            this.fieldFactory = fieldFactory;
        }

        public override void Enter()
        {

        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}