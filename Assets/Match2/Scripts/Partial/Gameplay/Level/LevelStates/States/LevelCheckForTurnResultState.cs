using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.Messages;
using MessagePipe;

namespace Match2.Partial.Gameplay.Level.LevelStates.States
{
    public class LevelCheckForTurnResultState : LevelState
    {
        private IFieldFactory fieldFactory;
        private readonly IPublisher<CheckForTurnResultMessage> onCheckForTurnResultPublisher;

        public LevelCheckForTurnResultState(LevelStateMachine levelStateMachine, IFieldFactory fieldFactory, IPublisher<CheckForTurnResultMessage> onCheckForTurnResultPublisher) : base(levelStateMachine)
        {
            this.fieldFactory = fieldFactory;
            this.onCheckForTurnResultPublisher = onCheckForTurnResultPublisher;
        }

        public override void Enter()
        {
            onCheckForTurnResultPublisher.Publish(new CheckForTurnResultMessage());
            //levelStateMachine.SetState<LevelPlayerActionState>();
        }

        public override void Update()
        {

        }

        public override void Exit()
        {

        }
    }
}