using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Static;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer;
using VContainer.Unity;

namespace Match2.Partial.UI.Factories
{
    public class GoalFrameFactory : IGoalFrameFactory
    {
        private AsyncOperationHandle<Sprite> handle;
        private LevelData currentLevelData;
        
        public GoalFrameFactory(LevelData levelData)
        {
            this.currentLevelData = levelData;
        }
        
        public async UniTask<GoalFrame> Create(GoalData data, RectTransform parent)
        {
            var instance = await Addressables.InstantiateAsync("GoalFrame", parent);
            var goalFrame = instance.GetComponent<GoalFrame>();
            
            var itemData = data.ItemData;
            handle = Addressables.LoadAssetAsync<Sprite>($"cube_{itemData.Color}_{itemData.Type}".ToLower());
            var sprite = await LoadAsyncOperationAsync(handle);
            goalFrame.Initialize(data, sprite);
            
            return goalFrame;
        }
        
        private async UniTask<T> LoadAsyncOperationAsync<T>(
            AsyncOperationHandle<T> asyncOperationHandle)
        {
            var instance = await asyncOperationHandle;
        
            return instance;
        }
    }
}