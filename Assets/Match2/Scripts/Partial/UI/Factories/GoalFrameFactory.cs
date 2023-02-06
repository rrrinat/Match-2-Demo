using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Static;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Match2.Partial.UI.Factories
{
    public class GoalFrameFactory : IGoalFrameFactory
    {
        private AsyncOperationHandle<Sprite> handle;

        public async UniTask<SpriteFrame> Create(GoalData data, RectTransform parent)
        {
            var instance = await Addressables.InstantiateAsync("GoalFrame", parent);
            var spriteFrame = instance.GetComponent<SpriteFrame>();
            
            var itemData = data.ItemData;
            handle = Addressables.LoadAssetAsync<Sprite>($"cube_{itemData.Color}_{itemData.Type}".ToLower());
            var sprite = await LoadAsyncOperationAsync(handle);
            
            spriteFrame.SetSprite(sprite);
            spriteFrame.SetLabel(data.Amount.ToString());

            return spriteFrame;
        }
        
        private async UniTask<T> LoadAsyncOperationAsync<T>(
            AsyncOperationHandle<T> asyncOperationHandle)
        {
            var instance = await asyncOperationHandle;

            return instance;
        }
    }
}