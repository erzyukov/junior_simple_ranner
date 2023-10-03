using UnityEngine;

namespace Game
{
    public class RoadMover : MonoBehaviour
    {
		[SerializeField] private float _speed;
		[SerializeField] private Transform _topScreenPoint;
		[SerializeField] private Transform _bottomScreenPoint;
		[SerializeField] private RoadSample[] _roadParts;

		private int _currentIndex;
		private int _partsCount;

		private void Start()
		{
			_partsCount = _roadParts.Length;
		}

		private void Update()
		{
			if (_roadParts[_currentIndex].TopPoint.position.y <= _bottomScreenPoint.position.y)
			{
				_roadParts[_currentIndex].transform.position = Vector3.up * _topScreenPoint.position.y;
				_currentIndex++;
				
				if (_currentIndex == _partsCount)
					_currentIndex = 0;
			}

			int nextPartIndex = (_currentIndex < _partsCount - 1) ? _currentIndex + 1 : 0;
			MoveRoadPart(nextPartIndex, Time.deltaTime);
			MoveRoadPart(_currentIndex, Time.deltaTime);
		}

		private void MoveRoadPart(int index, float deltaTime) =>
			_roadParts[index].transform.Translate(Vector3.down * _speed * deltaTime);
	}
}
