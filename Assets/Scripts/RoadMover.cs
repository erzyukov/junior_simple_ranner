using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Game
{
    public class RoadMover : MonoBehaviour
    {
		[SerializeField] private float _speed;
		[SerializeField] private RoadSample[] _roadParts;

		private int _currentIndex;
		private int _partsCount;

		private void Start()
		{
			_partsCount = _roadParts.Length;
		}

		private void Update()
		{
			int nextPartIndex = (_currentIndex < _partsCount - 1) ? _currentIndex + 1: 0;
			MoveRoadPart(nextPartIndex);
			MoveRoadPart(_currentIndex);

			if (_roadParts[_currentIndex].TopPoint.position.y < -30)
			{
				_roadParts[_currentIndex].transform.position = Vector3.up * 30;
				_currentIndex++;
				
				if (_currentIndex == _partsCount)
					_currentIndex = 0;
			}
		}

		private void MoveRoadPart(int index) =>
			_roadParts[index].transform.Translate(Vector3.down * _speed * Time.deltaTime);
	}
}
