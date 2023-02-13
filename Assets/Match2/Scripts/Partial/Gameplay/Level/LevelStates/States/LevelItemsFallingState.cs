using Match2.Partial.Gameplay.Factories;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level.LevelStates.States
{
    public class LevelItemsFallingState : LevelState
    {
        private IFieldFactory fieldFactory;
        private ItemsFall itemsFall;
        
        public LevelItemsFallingState(LevelStateMachine levelStateMachine, IFieldFactory fieldFactory, ItemsFall itemsFall) : base(levelStateMachine)
        {
            this.fieldFactory = fieldFactory;
            this.itemsFall = itemsFall;
        }

        public override async void Enter()
        {
            await itemsFall.Fall();

            levelStateMachine.SetState<LevelCheckForTurnResultState>();
        }
        
        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}