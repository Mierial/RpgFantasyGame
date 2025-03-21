using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CustomPool
{
    public class CustomPool<T> where T : MonoBehaviour
    {
        private T _prefab;
        private List<T> _objects;


        public CustomPool(T prefab, int prewarmObjects)
        {
            _prefab = prefab;
            _objects = new List<T>();

            for (int i = 0; i < prewarmObjects; i++)
            {
                var obj = Create();
                obj.gameObject.SetActive(false);
            }
        }

        public T Get(Vector3 position, Quaternion rotation)
        {
            var obj = _objects.FirstOrDefault(o => !o.gameObject.activeInHierarchy);

            if (obj == null)
            {
                obj = Create();
            }

            obj.gameObject.SetActive(true);
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            return obj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);
            if (!_objects.Contains(obj))
            {
                _objects.Add(obj);
            }
        }

        private T Create()
        {
            var obj = GameObject.Instantiate(_prefab);
            _objects.Add(obj);
            return obj;
        }
    }
}