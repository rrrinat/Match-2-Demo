using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.Factories;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level.LevelStates.States
{
    public class LevelFinishedState : LevelState
    {
        private IFieldFactory fieldFactory;
        private WindowPresenter windowPresenter;
        public LevelFinishedState(LevelStateMachine levelStateMachine, IFieldFactory fieldFactory, WindowPresenter windowPresenter) : base(levelStateMachine)
        {
            this.fieldFactory = fieldFactory;
            this.windowPresenter = windowPresenter;
        }

        public override void Enter()
        {
            Debug.Log($"LevelFinishedState");
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}