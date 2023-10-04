using UnityEngine;

namespace Game
{
    public class ScreensNavigator : MonoBehaviour
    {
		[SerializeField] private GameOverScreen _gameOverScreen;
		[SerializeField] private Player _player;

		private void Awake()
		{
			_player.Died += OnPlayerDied;
			Time.timeScale = 1;
		}

		private void OnDestroy()
		{
			_player.Died -= OnPlayerDied;
		}

		private void OnPlayerDied()
		{
			_gameOverScreen.gameObject.SetActive(true);
			Time.timeScale = 0;
		}
	}
}