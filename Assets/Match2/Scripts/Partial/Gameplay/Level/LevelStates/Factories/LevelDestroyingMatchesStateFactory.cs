using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level.LevelStates.States;
using Match2.Partial.Messages;
using MessagePipe;

namespace Match2.Partial.Gameplay.Level.LevelStates.Factories
{
    public class LevelDestroyingMatchesStateFactory
    {
        private readonly IFieldFactory fieldFactory;
        private readonly ISubscriber<OnMatchFoundMessage> onMatchFoundSubscriber;
        private readonly IPublisher<AfterDestroyMatchMessage> onAfterDestroyMatchPublisher;
        private readonly IPublisher<OnItemDestroyMessage> onItemDestroyPublisher;
        
        public LevelDestroyingMatchesStateFactory(IFieldFactory fieldFactory, ISubscriber<OnMatchFoundMessage> onMatchFoundSubscriber, IPublisher<AfterDestroyMatchMessage> onAfterDestroyMatchPublisher, IPublisher<OnItemDestroyMessage> onItemDestroyPublisher)
        {
            this.fieldFactory = fieldFactory;
            this.onMatchFoundSubscriber = onMatchFoundSubscriber;
            this.onAfterDestroyMatchPublisher = onAfterDestroyMatchPublisher;
            this.onItemDestroyPublisher = onItemDestroyPublisher;
        }
        
        public LevelDestroyingMatchesState Create(LevelStateMachine levelStateMachine) => new LevelDestroyingMatchesState(levelStateMachine, fieldFactory, onMatchFoundSubscriber, onAfterDestroyMatchPublisher, onItemDestroyPublisher);

    }
}