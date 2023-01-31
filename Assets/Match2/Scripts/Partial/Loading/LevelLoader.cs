using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Static;
using Match2.Partial.Scopes;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer;
using VContainer.Unity;

namespace Match2.Partial.Loading
{
    public class LevelLoader
    {
        private readonly LifetimeScope currentScope;
        private LevelLifetimeScope levelLifetimeScope;

        private AsyncOperationHandle<GameObject> handle;
        private GameObject lifetimeScopePrefab;

        public LevelLoader(LifetimeScope lifetimeScope)
        {
            currentScope = lifetimeScope;
        }

        public async UniTask Load(LevelData levelData)
        {
            handle = Addressables.LoadAssetAsync<GameObject>("LevelLifetimeScope");
            lifetimeScopePrefab = await LoadAsyncOperationAsync(handle);
            var instance = lifetimeScopePrefab.GetComponent<LevelLifetimeScope>();
            levelLifetimeScope = currentScope.CreateChildFromPrefab(
                instance, builder =>
                {
                    builder.RegisterInstance(levelData);
                });
        }

        private async UniTask<T> LoadAsyncOperationAsync<T>(
            AsyncOperationHandle<T> asyncOperationHandle)
        {
            var instance = await asyncOperationHandle;

            return instance;
        }

        public void Unload()
        {
            levelLifetimeScope.Dispose();
            Addressables.Release(handle);
        }
    }
}