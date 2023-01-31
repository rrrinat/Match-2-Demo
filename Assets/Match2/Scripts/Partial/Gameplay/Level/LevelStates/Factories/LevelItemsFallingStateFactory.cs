using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level.LevelStates.States;

namespace Match2.Partial.Gameplay.Level.LevelStates.Factories
{
    public class LevelItemsFallingStateFactory
    {
        private IFieldFactory fieldFactory;
        private ItemsFall itemsFall;
        
        public LevelItemsFallingStateFactory(IFieldFactory fieldFactory, ItemsFall itemsFall)
        {
            this.fieldFactory = fieldFactory;
            this.itemsFall = itemsFall;
        }
        
        public LevelItemsFallingState Create(LevelStateMachine levelStateMachine) => new LevelItemsFallingState(levelStateMachine, fieldFactory, itemsFall);

    }
}