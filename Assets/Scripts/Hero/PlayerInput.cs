using UnityEngine;

namespace Game
{
	[RequireComponent(typeof(PlayerMover))]
    public class PlayerInput : MonoBehaviour
    {
		private PlayerMover _playerMover;

		private void Start()
		{
			_playerMover = GetComponent<PlayerMover>();
		}

		private void Update()
		{
			int direction = (int)Input.GetAxisRaw("Horizontal");

			if (direction == 1)
			{
				_playerMover.MoveRight();
			}
			else if (direction == -1)
			{
				_playerMover.MoveLeft();
			}
		}
	}
}
