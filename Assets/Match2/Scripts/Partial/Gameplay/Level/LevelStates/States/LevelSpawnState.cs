using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.UI.Factories;
using Match2.Partial.UI.Windows;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level.LevelStates.States
{
    public class LevelSpawnState : LevelState
    {
        private IFieldFactory fieldFactory;
        private IGoalFrameFactory goalFrameFactory;
        private WindowPresenter windowPresenter;
        private LevelData levelData;
        
        public LevelSpawnState(LevelStateMachine levelStateMachine, IFieldFactory fieldFactory, IGoalFrameFactory goalFrameFactory, WindowPresenter windowPresenter, LevelData levelData) : base(levelStateMachine)
        {
            this.fieldFactory = fieldFactory;
            this.goalFrameFactory = goalFrameFactory;
            this.windowPresenter = windowPresenter;
            this.levelData = levelData;
        }

        public override async void Enter()
        {
            var field = fieldFactory.Create();

            var hudWindow = await windowPresenter.ShowAsync<GameplayHUDWindow>();
            hudWindow.SetData(levelData, goalFrameFactory);
            
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