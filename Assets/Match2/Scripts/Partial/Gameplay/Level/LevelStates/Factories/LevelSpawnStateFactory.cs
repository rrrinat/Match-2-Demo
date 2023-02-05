using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level.LevelStates.States;

namespace Match2.Partial.Gameplay.Level.LevelStates.Factories
{
    public class LevelSpawnStateFactory
    {
        private IFieldFactory fieldFactory;
        private WindowPresenter windowPresenter;
        
        public LevelSpawnStateFactory(IFieldFactory fieldFactory, WindowPresenter windowPresenter)
        {
            this.fieldFactory = fieldFactory;
            this.windowPresenter = windowPresenter;
        }
        
        public LevelSpawnState Create(LevelStateMachine levelStateMachine) => new LevelSpawnState(levelStateMachine, fieldFactory, windowPresenter);

    }
}