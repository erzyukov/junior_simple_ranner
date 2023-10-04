using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PowerUpSpawner : ObjectPool<PowerUp.Type>
	{
		[SerializeField] private float _spawnDelay;
		[SerializeField] private List<PowerUp> _powerUpPrefabs;
		[SerializeField] private Transform[] _spawnPoints;

		private void Start()
		{
			Dictionary<PowerUp.Type, GameObject> prefabs = new Dictionary<PowerUp.Type, GameObject>();
			_powerUpPrefabs.ForEach(prefab => prefabs.Add(prefab.PowerUpType, prefab.gameObject));
			Initialize(prefabs);

			StartCoroutine(StartSpawn());
		}

		private IEnumerator StartSpawn()
		{
			var wait = new WaitForSeconds(_spawnDelay);
			yield return wait;

			while (gameObject.activeInHierarchy)
			{
				Spawn();

				yield return wait;
			}
		}

		private void Spawn()
		{
			PowerUp.Type typeToSpawn = PowerUp.Type.RepairKit;
			GameObject powerUp = GetObject(typeToSpawn);
			Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
			powerUp.transform.position = spawnPoint.position;
			powerUp.SetActive(true);
		}
	}
}