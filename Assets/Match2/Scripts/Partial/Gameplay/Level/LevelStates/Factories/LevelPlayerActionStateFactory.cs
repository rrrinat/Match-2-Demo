using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level.LevelStates.States;
using Match2.Partial.Messages;
using MessagePipe;

namespace Match2.Partial.Gameplay.Level.LevelStates.Factories
{
    public class LevelPlayerActionStateFactory
    {
        private ItemsMatch itemsMatch;
        
        private IFieldFactory fieldFactory;
        private ISubscriber<OnCellClickedMessage> onCellClickedSubscriber;
        private ISubscriber<OnMatchFoundMessage> onMatchFoundSubscriber;
        
        public LevelPlayerActionStateFactory(IFieldFactory fieldFactory,ItemsMatch itemsMatch, ISubscriber<OnCellClickedMessage> onCellClickedSubscriber, ISubscriber<OnMatchFoundMessage> onMatchFoundSubscriber)
        {
            this.fieldFactory = fieldFactory;
            this.itemsMatch = itemsMatch;
            this.onCellClickedSubscriber = onCellClickedSubscriber;
            this.onMatchFoundSubscriber = onMatchFoundSubscriber;
        }
        
        public LevelPlayerActionState Create(LevelStateMachine levelStateMachine) => new LevelPlayerActionState(levelStateMachine, fieldFactory, itemsMatch, onCellClickedSubscriber, onMatchFoundSubscriber);
    }
}