using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level.LevelStates.States;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.UI.Factories;

namespace Match2.Partial.Gameplay.Level.LevelStates.Factories
{
    public class LevelSpawnStateFactory
    {
        private IFieldFactory fieldFactory;
        private IGoalFrameFactory goalFrameFactory;
        private WindowPresenter windowPresenter;
        private LevelData levelData;
        
        public LevelSpawnStateFactory(IFieldFactory fieldFactory, IGoalFrameFactory goalFrameFactory, WindowPresenter windowPresenter, LevelData levelData)
        {
            this.fieldFactory = fieldFactory;
            this.goalFrameFactory = goalFrameFactory;
            this.windowPresenter = windowPresenter;
            this.levelData = levelData;
        }
        
        public LevelSpawnState Create(LevelStateMachine levelStateMachine) => new LevelSpawnState(levelStateMachine, fieldFactory, goalFrameFactory, windowPresenter, levelData);

    }
}