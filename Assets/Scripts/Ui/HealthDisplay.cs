using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class HealthDisplay : MonoBehaviour
    {
		[SerializeField] private Player _player;
		[SerializeField] private Wheel _wheelPrefab;

		private Wheel[] _wheels;

		private void Awake()
		{
			_wheels = new Wheel[_player.BaseHealth];

			for (int i = 0; i < _player.BaseHealth; i++)
				_wheels[i] = Instantiate(_wheelPrefab, transform);

			_player.HealthChanged += OnHealthChanged;
		}

		private void OnDestroy()
		{
			_player.HealthChanged -= OnHealthChanged;
		}

		private void OnHealthChanged(int amount)
		{
            for (int i = 0; i < _wheels.Length; i++)
				_wheels[i].SetBroken(i >= amount);
        }
	}
}
