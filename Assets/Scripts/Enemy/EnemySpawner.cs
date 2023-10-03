using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class EnemySpawner : ObjectPool<Enemy.Type>
	{
		[Header("Pool Settings")]
		[Range(0, 1f)]
		[SerializeField] private float _spawnRate;
		[SerializeField] private float _spawnDelay;
		[SerializeField] private List<EnemyPrefab> _enemyPrefab;
		[SerializeField] private Transform[] _spawnPoints;

		private int _lastSpawnedPositionIndex = -1;

        private void Start()
        {
			Dictionary<Enemy.Type, GameObject> prefabs = new Dictionary<Enemy.Type, GameObject>();
			_enemyPrefab.ForEach(prefab => prefabs.Add(prefab.Type, prefab.Prefab));
			Initialize(prefabs);

			StartCoroutine(StartSpawn());
        }

		private IEnumerator StartSpawn()
		{
			var wait = new WaitForSeconds(_spawnDelay);

			while (gameObject.activeInHierarchy)
			{
				float spawnRate = Random.Range(0, 1f);

				if (spawnRate < _spawnRate)
					Spawn();

				yield return wait;
			}
		}

		private void Spawn()
		{
			int count = Enum.GetValues(typeof(Enemy.Type)).Length;
			Enemy.Type type = (Enemy.Type)Random.Range(0, count);
			GameObject enemy = GetObject(type);

			Transform spawnPoint = _spawnPoints
				.Where((element, index) => index != _lastSpawnedPositionIndex)
				.Skip(Random.Range(0, _spawnPoints.Length - 1))
				.First();
			_lastSpawnedPositionIndex = Array.IndexOf(_spawnPoints, spawnPoint);
			enemy.transform.position = spawnPoint.position;
			enemy.SetActive(true);
		}

		[Serializable]
		private struct EnemyPrefab
		{
			public Enemy.Type Type;
			public GameObject Prefab;
		}
    }
}