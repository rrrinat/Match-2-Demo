using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level.LevelStates.States;
using Match2.Partial.Gameplay.Static;

namespace Match2.Partial.Gameplay.Level.LevelStates.Factories
{
    public class LevelSpawnStateFactory
    {
        private IFieldFactory fieldFactory;
        private WindowPresenter windowPresenter;
        private LevelData levelData;
        
        public LevelSpawnStateFactory(IFieldFactory fieldFactory, WindowPresenter windowPresenter, LevelData levelData)
        {
            this.fieldFactory = fieldFactory;
            this.windowPresenter = windowPresenter;
            this.levelData = levelData;
        }
        
        public LevelSpawnState Create(LevelStateMachine levelStateMachine) => new LevelSpawnState(levelStateMachine, fieldFactory, windowPresenter, levelData);

    }
}