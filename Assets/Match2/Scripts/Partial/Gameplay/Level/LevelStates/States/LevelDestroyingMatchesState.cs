using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Entities;
using Match2.Partial.Gameplay.Factories;
using Match2.Partial.Messages;
using MessagePipe;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level.LevelStates.States
{
    public class LevelDestroyingMatchesState : LevelState
    {
        private IFieldFactory fieldFactory;
        
        private ISubscriber<OnMatchFoundMessage> onMatchFoundSubscriber;
        private IDisposable subscriptions;
        
        public LevelDestroyingMatchesState(LevelStateMachine levelStateMachine, IFieldFactory fieldFactory, ISubscriber<OnMatchFoundMessage> onMatchFoundSubscriber) : base(levelStateMachine)
        {
            this.fieldFactory = fieldFactory;
            this.onMatchFoundSubscriber = onMatchFoundSubscriber;
        }

        public override void Enter()
        {
            Debug.Log($"LevelDestroyingMatchesState Enter");
            
            var bag = DisposableBag.CreateBuilder();
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
        
        private void OnMatchFound(OnMatchFoundMessage message)
        {
            OnMatchFoundInternal(message.Cells).Forget();
        }
        
        private async UniTaskVoid OnMatchFoundInternal(HashSet<ICell> cells)
        {
            await DestroyMatch(cells);
            levelStateMachine.SetState<LevelItemsFallingState>();
        }
        
        private async UniTask DestroyMatch(HashSet<ICell> cells)
        {
            foreach (var cell in cells)
            {
                await Destroy(cell);
            }
        }
        
        private async UniTask Destroy(ICell cell)
        {
            if (!cell.IsInteractable)
            {
                return;
            }
            await cell.Child.Destroy();
        }
    }
}