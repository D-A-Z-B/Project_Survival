using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    public class Pool<T> where T : PoolableMono
    {
        private Stack<T> pool = new Stack<T>();
        private T prefab;
        private Transform parent;

        private PoolingType type;

        public Pool(T prefab, PoolingType type, Transform parent, int count)
        {
            this.prefab = prefab;
            this.type = type;
            this.parent = parent;

            for(int i = 0; i < count; i++)
            {
                T obj = GameObject.Instantiate(prefab, parent);
                obj.type = type;
                obj.gameObject.name = type.ToString();
                obj.gameObject.SetActive(false);
                pool.Push(obj);
            }
        }


        public T Pop()
        {
            T obj = null;
            if(pool.Count <= 0)
            {
                obj = GameObject.Instantiate(prefab, parent);
                obj.type = type;
                obj.gameObject.name = type.ToString();
            }
            else
            {
                obj = pool.Pop();
                obj.gameObject.SetActive(true);
            }
            return obj;
        }

        public void Push(T obj)
        {
            obj.gameObject.SetActive(false);
            pool.Push(obj);
        }
    }

}

