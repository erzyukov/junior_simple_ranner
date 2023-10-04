using UnityEngine;
using DG.Tweening;

namespace Game
{
    public class PowerUpAnimator : MonoBehaviour
    {
		[SerializeField] private float _targetScale;
		[SerializeField] private float _duration;

        private void Start()
        {
			transform.DOScale(_targetScale, _duration).SetEase(Ease.OutCubic).SetLoops(-1, LoopType.Yoyo);
        }
    }
}