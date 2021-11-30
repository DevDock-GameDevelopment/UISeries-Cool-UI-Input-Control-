using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace CoolUIElements.Assets.Scripts.UI
{
    public class CoolImage : MonoBehaviour
    {
        [Header("Animation Settings")]
        [SerializeField] private bool _animate;
        [SerializeField] private float _delay = 2f;
        [SerializeField] private float _duration = 1.5f;
        [SerializeField] private Transform _from;
        [SerializeField] private Transform _to;

        [Header("Image Settings")]
        [SerializeField] private Sprite _image;

        [Header("Controls")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Image _imageControl;
 
        private void OnEnable()
        {
            Display();
        }

        private void Display()
        {
            _imageControl.sprite = _image;

            if (_animate)
            {
                _canvasGroup.alpha = 0;
                _canvasGroup.transform.localPosition = _from.localPosition;

                Sequence animation = DOTween.Sequence();
                animation.SetDelay(_delay)
                .Append(_canvasGroup.gameObject.transform.DOLocalMove(_to.localPosition, _duration, true))
                .Join(_canvasGroup.DOFade(1, _duration));
            }
            else
            {
                _canvasGroup.alpha = 1;
                _canvasGroup.gameObject.transform.localPosition = _to.localPosition;
            }
        }

        /// <summary>
        /// Displays cool image control
        /// </summary>
        /// <param name="delay">Delay before display</param>
        public void Show(float delay)
        {
            _delay = delay;
            _canvasGroup.gameObject.SetActive(true);
        }

        /// <summary>
        /// Hides cool image control
        /// </summary>
        public void Hide()
        {
            _canvasGroup.gameObject.SetActive(false);
        }

        /// <summary>
        /// Loads sprite in the image control
        /// </summary>
        /// <param name="sprite">Sprite to load</param>
        public void LoadImage(Sprite sprite)
        {
            _imageControl.sprite = sprite;
        }

    }
}