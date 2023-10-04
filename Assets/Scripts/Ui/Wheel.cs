using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	[RequireComponent(typeof(Image))]
	public class Wheel : MonoBehaviour
	{
		[SerializeField] private Sprite _wheel;
		[SerializeField] private Sprite _brokenWheel;

		private Image _image;

		private void OnEnable()
		{
			_image = GetComponent<Image>();
		}

		public void SetBroken(bool isBorken) =>
			_image.sprite = (isBorken) ? _brokenWheel : _wheel;
	}
}
