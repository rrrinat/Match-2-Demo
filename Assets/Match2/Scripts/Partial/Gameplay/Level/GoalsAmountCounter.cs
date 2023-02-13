using System;
using System.Linq;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.Messages;
using MessagePipe;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level
{
    public class GoalsAmountCounter : IDisposable
    {
        private LevelData currentLevelData; 
        private readonly ISubscriber<OnItemDestroyMessage> onItemDestroySubscriber;
        private IDisposable subscriptions;
        
        public GoalsAmountCounter(LevelData levelData, ISubscriber<OnItemDestroyMessage> onItemDestroySubscriber)
        {
            this.currentLevelData = levelData;
            this.onItemDestroySubscriber = onItemDestroySubscriber;
            
            var bag = DisposableBag.CreateBuilder();
            onItemDestroySubscriber.Subscribe(OnItemDestroy).AddTo(bag);
            subscriptions = bag.Build();
        }
        private void OnItemDestroy(OnItemDestroyMessage message)
        {
            var itemData = message.ItemData;
            var goals = currentLevelData.Goals;

            if (!currentLevelData.TryGetGoalData(itemData, out var goalData))
            {
                return;
            }
            
            if (goalData.Amount <= 0)
            {
                return;
            }

            goalData.Amount.Value--;
            goals[itemData] = goalData;

            // var allItemsDestroyed = goals.Values.All(i => i.Amount <= 0);
            // if (allItemsDestroyed)
            // {
            //     Dispose();
            //     
            // }
        }

        public void Dispose()
        {
            subscriptions?.Dispose();
        }
    }
}
