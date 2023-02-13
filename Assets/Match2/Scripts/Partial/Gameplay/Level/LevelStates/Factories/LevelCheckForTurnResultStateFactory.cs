using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Level.LevelStates.States;
using Match2.Partial.Messages;
using MessagePipe;

namespace Match2.Partial.Gameplay.Level.LevelStates.Factories
{
    public class LevelCheckForTurnResultStateFactory
    {
        private IFieldFactory fieldFactory;
        private readonly IPublisher<CheckForTurnResultMessage> onCheckForTurnResultPublisher;
        private GoalsAchievedChecker goalsAchievedChecker;
        private LimitedMovesGameOverChecker limitedMovesGameOverChecker;

        public LevelCheckForTurnResultStateFactory(IFieldFactory fieldFactory,
            IPublisher<CheckForTurnResultMessage> onCheckForTurnResultPublisher,
            GoalsAchievedChecker goalsAchievedChecker, LimitedMovesGameOverChecker limitedMovesGameOverChecker)
        {
            this.fieldFactory = fieldFactory;
            this.onCheckForTurnResultPublisher = onCheckForTurnResultPublisher;
            this.goalsAchievedChecker = goalsAchievedChecker;
            this.limitedMovesGameOverChecker = limitedMovesGameOverChecker;
        }

        public LevelCheckForTurnResultState Create(LevelStateMachine levelStateMachine) =>
            new LevelCheckForTurnResultState(levelStateMachine, fieldFactory, onCheckForTurnResultPublisher,
                goalsAchievedChecker, limitedMovesGameOverChecker);
    }
}