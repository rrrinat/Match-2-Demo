using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level.LevelStates.States;

namespace Match2.Partial.Gameplay.Level.LevelStates.Factories
{
    public class LevelSpawnStateFactory
    {
        private IFieldFactory fieldFactory;
        
        public LevelSpawnStateFactory(IFieldFactory fieldFactory)
        {
            this.fieldFactory = fieldFactory;
        }
        
        public LevelSpawnState Create(LevelStateMachine levelStateMachine) => new LevelSpawnState(levelStateMachine, fieldFactory);

    }
}