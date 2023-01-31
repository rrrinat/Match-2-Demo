using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level.LevelStates.States;
using Match2.Partial.Messages;
using MessagePipe;

namespace Match2.Partial.Gameplay.Level.LevelStates.Factories
{
    public class LevelDestroyingMatchesStateFactory
    {
        private IFieldFactory fieldFactory;
        private ISubscriber<OnMatchFoundMessage> onMatchFoundSubscriber;

        
        public LevelDestroyingMatchesStateFactory(IFieldFactory fieldFactory, ISubscriber<OnMatchFoundMessage> onMatchFoundSubscriber)
        {
            this.fieldFactory = fieldFactory;
            this.onMatchFoundSubscriber = onMatchFoundSubscriber;
        }
        
        public LevelDestroyingMatchesState Create(LevelStateMachine levelStateMachine) => new LevelDestroyingMatchesState(levelStateMachine, fieldFactory, onMatchFoundSubscriber);

    }
}