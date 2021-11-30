using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CoolUIElements.Assets.Scripts.UI
{
    public class CoolListItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        [Header("Properties")]
        [SerializeField] private float _transationDuration = .5f;

        [Header("Controls")]
        [SerializeField] private Image _backgroundControl;
        [SerializeField] private Image _imageControl;
        [SerializeField] private TextMeshProUGUI _textControl;

        [Header("Colors")]
        [SerializeField] private Color _defaultBackgroundColor = Color.white;
        [SerializeField] private Color _hoverBackgroundColor = Color.white;
        [SerializeField] private Color _clickBackgroundColor = Color.white;

        private UnityAction _calLBack;
        public void OnPointerDown(PointerEventData eventData)
        {
            _calLBack?.Invoke();

            Sequence clickSequence = DOTween.Sequence();
            clickSequence
            .Append((DOTween.To(() => _backgroundControl.color, x => _backgroundControl.color = x, _clickBackgroundColor, _transationDuration)
            .OnComplete( () => DOTween.To(() => _backgroundControl.color, x => _backgroundControl.color = x, _defaultBackgroundColor, _transationDuration))));
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Sequence enterSequence = DOTween.Sequence();
            enterSequence
            .Append(DOTween.To(() => _backgroundControl.color, x => _backgroundControl.color = x, _hoverBackgroundColor, _transationDuration));
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Sequence exitSequence = DOTween.Sequence();
            exitSequence
            .Append(DOTween.To(() => _backgroundControl.color, x => _backgroundControl.color = x, _defaultBackgroundColor, _transationDuration));
        }

        /// <summary>
        /// Sets image and text control
        /// </summary>
        /// <param name="image">Image to set</param>
        /// <param name="text">Title to set</param>
        public void SetItem(Sprite image, string text)
        {
            _imageControl.sprite = image;
            _textControl.SetText(text);
        }

        /// <summary>
        /// Registers call back action
        /// </summary>
        /// <param name="callBack">Action to register as call back</param>
        public void RegisterCallBack(UnityAction callBack)
        {
            _calLBack = callBack;
        }

    }
}