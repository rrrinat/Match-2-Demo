using System;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.Messages;
using MessagePipe;

namespace Match2.Partial.Gameplay.Level
{
    public class PlayerMovesCounter : IDisposable
    {
        private LevelData currentLevelData;
        private readonly ISubscriber<CheckForTurnResultMessage> onCheckForTurnResultSubscriber;

        private IDisposable subscriptions;
        
        public PlayerMovesCounter(LevelData levelData, ISubscriber<CheckForTurnResultMessage> onCheckForTurnResultSubscriber)
        {
            this.currentLevelData = levelData;
            this.onCheckForTurnResultSubscriber = onCheckForTurnResultSubscriber;

            var bag = DisposableBag.CreateBuilder();
            onCheckForTurnResultSubscriber.Subscribe(OnCheckForTurnResult).AddTo(bag);
            subscriptions = bag.Build();
        }
        
        private void OnCheckForTurnResult(CheckForTurnResultMessage message)
        {
            currentLevelData.MovesCount.Value--;

            // if (currentLevelData.MovesCount <= 0)
            // {
            //     Dispose();
            // }
        }

        public void Dispose()
        {
            subscriptions?.Dispose();
        }
    }
}
