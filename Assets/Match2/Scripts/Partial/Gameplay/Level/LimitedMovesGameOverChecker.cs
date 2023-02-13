using System;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.Messages;
using MessagePipe;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level
{
    public class LimitedMovesGameOverChecker : IDisposable
    {
        private LevelData currentLevelData;
        private readonly ISubscriber<AfterDestroyMatchMessage> onAfterDestroyMatchSubscriber;

        private IDisposable subscriptions;
        
        public LimitedMovesGameOverChecker(LevelData levelData, ISubscriber<AfterDestroyMatchMessage> onAfterDestroyMatchSubscriber)
        {
            this.currentLevelData = levelData;
            this.onAfterDestroyMatchSubscriber = onAfterDestroyMatchSubscriber;

            var bag = DisposableBag.CreateBuilder();
            onAfterDestroyMatchSubscriber.Subscribe(OnAfterDestroyMatch).AddTo(bag);
            subscriptions = bag.Build();
        }
        
        private void OnAfterDestroyMatch(AfterDestroyMatchMessage message)
        {
            currentLevelData.MovesCount.Value--;

            if (currentLevelData.MovesCount <= 0)
            {
                Dispose();
            }        
        }

        public void Dispose()
        {
            subscriptions?.Dispose();
        }
    }
}
