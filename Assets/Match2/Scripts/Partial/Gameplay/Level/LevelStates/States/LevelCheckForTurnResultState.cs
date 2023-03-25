using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Messages;
using MessagePipe;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level.LevelStates.States
{
    public class LevelCheckForTurnResultState : LevelState
    {
        private IFieldFactory fieldFactory;
        private readonly IPublisher<CheckForTurnResultMessage> onCheckForTurnResultPublisher;
        private GoalsAchievedChecker goalsAchievedChecker;
        private LimitedMovesGameOverChecker limitedMovesGameOverChecker;

        public LevelCheckForTurnResultState(LevelStateMachine levelStateMachine, IFieldFactory fieldFactory,
            IPublisher<CheckForTurnResultMessage> onCheckForTurnResultPublisher,
            GoalsAchievedChecker goalsAchievedChecker, LimitedMovesGameOverChecker limitedMovesGameOverChecker) : base(
            levelStateMachine)
        {
            this.fieldFactory = fieldFactory;
            this.onCheckForTurnResultPublisher = onCheckForTurnResultPublisher;
            this.goalsAchievedChecker = goalsAchievedChecker;
            this.limitedMovesGameOverChecker = limitedMovesGameOverChecker;
        }

        public override void Enter()
        {
            onCheckForTurnResultPublisher.Publish(new CheckForTurnResultMessage());

            if (goalsAchievedChecker.IsGoalsAchieved())
            {
                Debug.Log($"Goals Achieved!");

                return;
            }

            if (limitedMovesGameOverChecker.IsMovesOver())
            {
                Debug.Log($"Moves Over!");

                return;
            }
            
            levelStateMachine.SetState<LevelPlayerActionState>();
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }
    }
}