using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class ObjectPool<T> : MonoBehaviour where T : Enum
    {
		[Header("Pool Settings")]
		[SerializeField] private GameObject _container;
		[SerializeField] private int _elementCapacity;

		private Dictionary<T, List<GameObject>> _pool;
		private Dictionary<T, GameObject> _prefabs;

		protected void Initialize(Dictionary<T, GameObject> prefabs)
		{
			_pool = new Dictionary<T, List<GameObject>>();
			_prefabs = prefabs;

			foreach (var prefab in prefabs)
			{
				for (int i = 0; i < _elementCapacity; i++)
					ExpandPoolByOne(prefab.Key);
            }
		}

		protected GameObject GetObject(T type)
		{
			if (_pool.ContainsKey(type) == false)
				throw new Exception($"Prefab with type {type} absent in pool!");

			Func<GameObject, bool> whereInactives = element => element.activeSelf == false;

			if (_pool[type].Count(whereInactives) == 0)
				ExpandPoolByOne(type);

			GameObject founded = _pool[type].First(whereInactives);

			return founded;
		}

		private void ExpandPoolByOne(T type)
		{
			if (_pool.ContainsKey(type) == false)
				_pool.Add(type, new List<GameObject>());

			GameObject spawned = Instantiate(_prefabs[type], _container.transform);
			spawned.SetActive(false);

			_pool[type].Add(spawned);
		}
	}
}