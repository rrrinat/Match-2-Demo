using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Match2.Partial.Gameplay.Enums;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Match2.Partial.Gameplay.VFX
{
    public class ItemDestroyPoolCollection : IDisposable
    {
        private int initialInstanceCount = 20;
        private Dictionary<ItemColor, ItemDestroyPool> pools;
        private Stack<AsyncOperationHandle<GameObject>> handles;

        public ItemDestroyPoolCollection()
        {
            handles = new Stack<AsyncOperationHandle<GameObject>>();
            pools = new Dictionary<ItemColor, ItemDestroyPool>();
            
            CreatePools().Forget();       
        }

        private async UniTask CreatePools()
        {
            var managerHost = new GameObject("ItemDestroyPoolCollection");
            var colors = Enum.GetValues(typeof(ItemColor));
            
            for (int i = 0; i < 7; i++)
            {
                var color = (ItemColor)colors.GetValue(i);
                if (color == ItemColor.None)
                {
                    continue;
                }

                var host = new GameObject(color.ToString());
                host.transform.SetParent(managerHost.transform);

                var handle = Addressables.LoadAssetAsync<GameObject>($"Cube_{color.ToString()}_Destroy".ToLower());
                handles.Push(handle);
                
                var prefab = await LoadAsyncOperationAsync(handle);
                pools.Add(color, new ItemDestroyPool(prefab, host.transform, initialInstanceCount));
            }      
        }
        
        private async UniTask<T> LoadAsyncOperationAsync<T>(
            AsyncOperationHandle<T> asyncOperationHandle)
        {
            var instance = await asyncOperationHandle;

            return instance;
        }
        
        public bool SpawnVFX(ItemColor color, Vector3 position)
        {
            if (color == ItemColor.None || !pools.ContainsKey(color))
            {
                return false;
            }

            InternalSpawnEffect(color, position);
            return true;
        }

        public async void SpawnEffectAndReturn(ItemColor color, Vector3 position)
        {
            if (color == ItemColor.None || !pools.ContainsKey(color))
            {
                return;
            }

            var vfx = InternalSpawnEffect(color, position);
            await WaitAndReturn(vfx);
        }

        private async UniTask WaitAndReturn(ItemDestroyEffect vfx)
        {
            await UniTask.Delay(2000);
            if (vfx == null)
            {
                return;
            }
            
            pools[vfx.Color].Return(vfx);
        }
        
        private ItemDestroyEffect InternalSpawnEffect(ItemColor color, Vector3 position)
        {
            var pool = pools[color];

            var vfx = pool.Get(position, Quaternion.identity);
            vfx.Color = color;

            return vfx;
        }
        
        public void Return(ItemDestroyEffect vfx)
        {
            pools[vfx.Color].Return(vfx);
        }

        public void Dispose()
        {
            while (handles.Count > 0)
            {
                var current = handles.Pop();
                Addressables.Release(current);
            }
        }
    }
}
