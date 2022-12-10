using System.Collections.Generic;
using UnityEngine;

namespace _GAME_.Scripts.Extensions
{
    public class CustomObjectPool<T> where T : MonoBehaviour
    {
        #region Private Variables

        private readonly Transform _poolParent;
        private readonly Queue<T> _objects;
        private readonly T _prefab;

        #endregion

        #region Constructor

        public CustomObjectPool(T prefab, int initialCapacity, Transform poolParent = null)
        {
            _poolParent = poolParent;
            _objects = new Queue<T>(initialCapacity);
            _prefab = prefab;
        }

        #endregion

        #region Public Methods

        public T Get()
        {
            if (_objects.Count == 0)
            {
                AddObjects(1);
            }

            T obj = _objects.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void AddObjects(int count)
        {
            for (int i = 0; i < count; i++)
            {
                T obj = GameObject.Instantiate(_prefab, _poolParent);
                obj.gameObject.SetActive(false);
                _objects.Enqueue(obj);
            }
        }

        public void ReturnObject(T obj)
        {
            obj.gameObject.SetActive(false);
            _objects.Enqueue(obj);
        }

        #endregion
    }
}