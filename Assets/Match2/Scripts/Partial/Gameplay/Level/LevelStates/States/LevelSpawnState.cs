using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.Factories;
using Match2.Partial.UI.Windows;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level.LevelStates.States
{
    public class LevelSpawnState : LevelState
    {
        private IFieldFactory fieldFactory;
        private WindowPresenter windowPresenter;
        
        public LevelSpawnState(LevelStateMachine levelStateMachine, IFieldFactory fieldFactory, WindowPresenter windowPresenter) : base(levelStateMachine)
        {
            this.fieldFactory = fieldFactory;
            this.windowPresenter = windowPresenter;
        }

        public override async void Enter()
        {
            Debug.Log($"LevelSpawnState Enter");
            
            var field = fieldFactory.Create();

            await windowPresenter.ShowAsync<GameplayHUDWindow>();
            
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