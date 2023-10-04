using UnityEngine;

namespace Game
{
    public class PlayerMover : MonoBehaviour
    {
		[SerializeField] private float _speed;
		[SerializeField] private float _stepSize;
		[SerializeField] private float _maxDeviation;

		private Vector3 _targetPosition;

		private void Start()
		{
			_targetPosition = transform.position;
		}

		private void Update()
		{
			if (transform.position != _targetPosition)
				transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
		}

		public void MoveLeft()
		{
			if (_targetPosition.x > -_maxDeviation)
				TrySetNextPosition(-_stepSize);
		}

		public void MoveRight()
		{
			if (_targetPosition.x < _maxDeviation)
				TrySetNextPosition(_stepSize);
		}

		private void TrySetNextPosition(float stepSize)
		{
			if (_targetPosition == transform.position)
				_targetPosition = new Vector3(_targetPosition.x + stepSize, _targetPosition.y, 0);
		}
	}
}
