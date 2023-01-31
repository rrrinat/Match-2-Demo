using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level.LevelStates.States;

namespace Match2.Partial.Gameplay.Level.LevelStates.Factories
{
    public class LevelClearStateFactory
    {
        private IFieldFactory fieldFactory;
        
        public LevelClearStateFactory(IFieldFactory fieldFactory)
        {
            this.fieldFactory = fieldFactory;
        }
        
        public LevelClearState Create(LevelStateMachine levelStateMachine) => new LevelClearState(levelStateMachine, fieldFactory);

    }
}