using System;
using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Messages;
using MessagePipe;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level.LevelStates.States
{
    public class LevelPlayerActionState : LevelState
    {
        private ItemsMatch itemsMatch;

        private IFieldFactory fieldFactory;
        private ISubscriber<OnCellClickedMessage> onCellClickedSubscriber;
        private ISubscriber<OnMatchFoundMessage> onMatchFoundSubscriber;
        private IDisposable subscriptions;


        public LevelPlayerActionState(LevelStateMachine levelStateMachine, IFieldFactory fieldFactory,
            ItemsMatch itemsMatch, ISubscriber<OnCellClickedMessage> onCellClickedSubscriber,
            ISubscriber<OnMatchFoundMessage> onMatchFoundSubscriber) : base(levelStateMachine)
        {
            this.fieldFactory = fieldFactory;
            this.itemsMatch = itemsMatch;
            this.onCellClickedSubscriber = onCellClickedSubscriber;
            this.onMatchFoundSubscriber = onMatchFoundSubscriber;
        }

        public override void Enter()
        {
            var bag = DisposableBag.CreateBuilder();
            onCellClickedSubscriber.Subscribe(OnCellClicked).AddTo(bag);
            onMatchFoundSubscriber.Subscribe(OnMatchFound).AddTo(bag);
            subscriptions = bag.Build();
        }
        
        public override void Update()
        {
        }

        public override void Exit()
        {
            
            
            subscriptions.Dispose();
        }
        
        private void OnCellClicked(OnCellClickedMessage message)
        {
            itemsMatch.OnCellClicked(message.Coord);
        }

        private void OnMatchFound(OnMatchFoundMessage message)
        {
            levelStateMachine.SetState<LevelDestroyingMatchesState>();
        }
    }
}