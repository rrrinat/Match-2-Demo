using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level.LevelStates.States;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.Messages;
using MessagePipe;

namespace Match2.Partial.Gameplay.Level.LevelStates.Factories
{
    public class LevelCheckForTurnResultStateFactory
    {
        private IFieldFactory fieldFactory;
        private readonly IPublisher<CheckForTurnResultMessage> onCheckForTurnResultPublisher;

        public LevelCheckForTurnResultStateFactory(IFieldFactory fieldFactory, IPublisher<CheckForTurnResultMessage> onCheckForTurnResultPublisher)
        {
            this.fieldFactory = fieldFactory;
            this.onCheckForTurnResultPublisher = onCheckForTurnResultPublisher;
        }
        
        public LevelCheckForTurnResultState Create(LevelStateMachine levelStateMachine) => new LevelCheckForTurnResultState(levelStateMachine, fieldFactory, onCheckForTurnResultPublisher);

    }
}