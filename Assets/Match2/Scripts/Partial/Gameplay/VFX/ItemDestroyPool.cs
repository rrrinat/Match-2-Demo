using Match2.Common.Utils;
using UnityEngine;

namespace Match2.Partial.Gameplay.VFX
{
    public class ItemDestroyPool : PoolBase<ItemDestroyEffect>
    {
        public ItemDestroyPool(GameObject prefab, Transform parent, int initialInstanceCount) : base(prefab, parent, initialInstanceCount)
        {
            
        }
    }
}