using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level.LevelStates.States;

namespace Match2.Partial.Gameplay.Level.LevelStates.Factories
{
    public class LevelIdleStateFactory
    {
        private IFieldFactory fieldFactory;
        
        public LevelIdleStateFactory(IFieldFactory fieldFactory)
        {
            this.fieldFactory = fieldFactory;
        }
        
        public LevelIdleState Create(LevelStateMachine levelStateMachine) => new LevelIdleState(levelStateMachine, fieldFactory);

    }
}