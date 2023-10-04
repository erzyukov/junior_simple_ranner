using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class Player : MonoBehaviour
    {
		[SerializeField] private int _baseHealth;

		private int _health;

		public event UnityAction<int> HealthChanged;
		public event UnityAction Died;

		public int BaseHealth => _baseHealth;

		private void Start()
		{
			_health = _baseHealth;
			HealthChanged?.Invoke(_health);
		}

		public void ApplyDamage()
		{
			_health--;

			if (_health < 0)
				_health = 0;

			HealthChanged?.Invoke(_health);

			if (_health == 0)
				Died?.Invoke();
		}

		public void ApplyRepair()
		{
			_health++;

			if (_health > _baseHealth)
				_health = _baseHealth;

			HealthChanged?.Invoke(_health);
		}
	}
}
