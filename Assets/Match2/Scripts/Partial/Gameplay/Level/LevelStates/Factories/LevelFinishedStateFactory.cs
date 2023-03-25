using Match2.Common.UI.Windows;
using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level.LevelStates.States;

namespace Match2.Partial.Gameplay.Level.LevelStates.Factories
{
    public class LevelFinishedStateFactory
    {
        private IFieldFactory fieldFactory;
        private WindowPresenter windowPresenter;
        
        public LevelFinishedStateFactory(IFieldFactory fieldFactory, WindowPresenter windowPresenter)
        {
            this.fieldFactory = fieldFactory;
            this.windowPresenter = windowPresenter;
        }
        
        public LevelFinishedState Create(LevelStateMachine levelStateMachine) => new LevelFinishedState(levelStateMachine, fieldFactory, windowPresenter);
    }
}