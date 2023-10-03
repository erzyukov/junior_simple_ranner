using UnityEngine;

namespace Game
{
    public class EnemyMover : MonoBehaviour
    {
		[SerializeField] private float _minEnemySpeed;
		[SerializeField] private float _maxEnemySpeed;

		private float _speed;

		private void OnEnable()
        {
			_speed = Random.Range(_minEnemySpeed, _maxEnemySpeed);
        }

		private void Update()
        {
			transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
	}
}
