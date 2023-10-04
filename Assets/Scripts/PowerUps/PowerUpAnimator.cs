using UnityEngine;
using DG.Tweening;

namespace Game
{
    public class PowerUpAnimator : MonoBehaviour
    {
		[SerializeField] private float _targetScale;
		[SerializeField] private float _duration;

		private Tween _animation;

        private void OnEnable()
        {
			_animation = transform.DOScale(_targetScale, _duration).SetEase(Ease.OutCubic).SetLoops(-1, LoopType.Yoyo);
        }

		private void OnDisable()
		{
			_animation.Kill();
		}
	}
}