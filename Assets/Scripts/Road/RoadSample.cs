using UnityEngine;

namespace Game
{
    public class RoadSample : MonoBehaviour
    {
		[SerializeField] private Transform _topPoint;

		public Transform TopPoint => _topPoint;
    }
}