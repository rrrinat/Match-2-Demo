using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Entities;
using Match2.Partial.Gameplay.Static;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Match2.Partial.Gameplay.Factories
{
    public class ItemViewFactory : IItemViewFactory
    {
        private AsyncOperationHandle<Sprite> handle;
        
        public async UniTask<IItemView> Create(ItemData itemData, ICell parent)
        {
            var instance = await Addressables.InstantiateAsync("Common");
            handle = Addressables.LoadAssetAsync<Sprite>($"cube_{itemData.Color}_{itemData.Type}".ToLower());
            var sprite = await LoadAsyncOperationAsync(handle);

            var view = instance.GetComponent<IItemView>();
            view.transform.SetParent(parent.transform, false);
            view.Initialize(sprite);

            return view;
        }
        
        private async UniTask<T> LoadAsyncOperationAsync<T>(
            AsyncOperationHandle<T> asyncOperationHandle)
        {
            var instance = await asyncOperationHandle;

            return instance;
        }
    }
}