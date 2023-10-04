using UnityEngine;

namespace Game
{
	abstract public class PowerUp : MonoBehaviour
    {
		public enum Type
		{
			RepairKit
		}

		public abstract Type PowerUpType { get; }

		protected abstract void Apply(Player player);

		private void OnTriggerEnter2D(Collider2D collision)
		{
			Player player = collision.GetComponent<Player>();
			if (player != null)
				Apply(player);
			gameObject.SetActive(false);
		}
	}
}