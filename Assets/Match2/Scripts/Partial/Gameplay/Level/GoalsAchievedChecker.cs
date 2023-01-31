using System;
using Match2.Partial.Messages;
using MessagePipe;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level
{
    public class GoalsAchievedChecker : IDisposable
    {
        private readonly ISubscriber<OnItemDestroyMessage> onItemDestroySubscriber;
        private IDisposable subscriptions;
        
        public GoalsAchievedChecker(ISubscriber<OnItemDestroyMessage> onItemDestroySubscriber)
        {
            this.onItemDestroySubscriber = onItemDestroySubscriber;
            
            var bag = DisposableBag.CreateBuilder();
            onItemDestroySubscriber.Subscribe(OnItemDestroy).AddTo(bag);
            subscriptions = bag.Build();
            
            Debug.Log($"GoalsAchievedChecker");
        }
        private void OnItemDestroy(OnItemDestroyMessage message)
        {
            Debug.Log($"On Item Destoy {message.ItemData.ToString()}");
        }

        public void Dispose()
        {
            subscriptions?.Dispose();
        }
    }
}
