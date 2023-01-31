using System.Collections.Generic;
using UnityEngine;

namespace Match2.Common.Utils
{
    public abstract class PoolBase<T> where T : MonoBehaviour
    {
        private Queue<T> pool;
        private GameObject prefab;
        private Transform parent;
        
        public int Count
        {
            get { return pool.Count; }
        }
        
        public PoolBase(GameObject prefab, Transform parent, int initialInstanceCount)
        {
            this.pool = new Queue<T>(initialInstanceCount);
            this.prefab = prefab;
            this.parent = parent;
            
            for (int i = 0; i < initialInstanceCount; i++)
            {
                this.pool.Enqueue(CreateInstance());
            }
        }
        
        public T Get(Vector3 position, Quaternion rotation)
        {
            T entity;
            if (pool.Count > 0)
            {
                entity = pool.Dequeue();
            }
            else
            {
                entity = CreateInstance();
            }

            var t = entity.transform;

            t.position = position;
            t.rotation = rotation;

            entity.gameObject.SetActive(true);
            return entity;
        }
        
        public void Return(T entity)
        {
            entity.transform.SetParent(parent);
            entity.gameObject.SetActive(false);
            pool.Enqueue(entity);
        }

        private T CreateInstance()
        {
            var go = GameObject.Instantiate(prefab, parent);
            go.SetActive(false);
            return go.GetComponent<T>();
        }
    }
}
