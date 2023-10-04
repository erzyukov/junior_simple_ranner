using UnityEngine;

namespace Game
{
    public class Enemy : MonoBehaviour
    {
		public enum Type
		{
			Enemy1,
			Enemy2,
			Enemy3
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			Player player = collision.GetComponent<Player>();

			if (player != null)
				player.ApplyDamage();

			gameObject.SetActive(false);
		}
    }
}
