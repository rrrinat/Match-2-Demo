using System;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.Messages;
using MessagePipe;
using UnityEngine;

namespace Match2.Partial.Gameplay.Level
{
    public class GoalsAchievedChecker : IDisposable
    {
        private LevelData currentLevelData; 
        private readonly ISubscriber<OnItemDestroyMessage> onItemDestroySubscriber;
        private IDisposable subscriptions;
        
        public GoalsAchievedChecker(LevelData levelData, ISubscriber<OnItemDestroyMessage> onItemDestroySubscriber)
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
            var itemIndex = goals.FindIndex(g => g.ItemData.Equals(itemData));
            if (itemIndex < 0)
            {
                return;
            }
            
            var goalData = goals[itemIndex];
            if (goalData.Amount <= 0)
            {
                return;
            }

            goalData.Amount--;
            goals[itemIndex] = goalData;
            
            Debug.Log(goalData.ToString());
        }

        public void Dispose()
        {
            subscriptions?.Dispose();
        }
    }
}
