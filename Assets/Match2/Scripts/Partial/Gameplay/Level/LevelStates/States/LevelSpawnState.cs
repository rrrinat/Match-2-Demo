using Match2.Partial.Gameplay.Factories;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level.LevelStates.States
{
    public class LevelSpawnState : LevelState
    {
        private IFieldFactory fieldFactory;
        
        public LevelSpawnState(LevelStateMachine levelStateMachine, IFieldFactory fieldFactory) : base(levelStateMachine)
        {
            this.fieldFactory = fieldFactory;
        }

        public override void Enter()
        {
            Debug.Log($"LevelSpawnState Enter");
            
            var field = fieldFactory.Create();
            
            levelStateMachine.SetState<LevelPlayerActionState>();
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}