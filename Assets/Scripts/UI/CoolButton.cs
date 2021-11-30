using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CoolUIElements.Assets.Scripts.UI
{
    public class CoolButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {

        [Header("Propterties")]
        [SerializeField] private string _title;

        [Header("Font Colors")]
        [SerializeField] private Color _defaultTextColor = Color.white;
        [SerializeField] private Color _hoverTextColor = Color.white;
        [SerializeField] private Color _clickTextColor = Color.white;

        [Header("Background Colors")]
        [SerializeField] private Color _defaultBackgroundColor = Color.white;
        [SerializeField] private Color _hoverBackgroundColor = Color.white;
        [SerializeField] private Color _clickBackgroundColor = Color.white;

        [Header("Animation Settings")]
        [SerializeField] private float _hoverAnimationDuration = .5f;
        [SerializeField] private float _defaultAnimationDuration = .5f;
        [SerializeField] private float _clickAnimationDuration = .5f;

        [Header("Controls")]
        [SerializeField] private TextMeshProUGUI _titleControl;
        [SerializeField] private Image _defaultBackgroundImage;
        [SerializeField] private Image _hoverBackgroundImage;
        [SerializeField] private CanvasGroup _defaultCanvasGroup;
        [SerializeField] private CanvasGroup _hoverCanvasGroup;

        private UnityAction _callBackAction;

        private void OnValidate()
        {
            _titleControl.SetText(_title);
            _titleControl.color = _defaultTextColor;

            _defaultBackgroundImage.color = _defaultBackgroundColor;
            _hoverBackgroundImage.color = _hoverBackgroundColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Sequence enterSequence = DOTween.Sequence();
            enterSequence
            .Append(DOTween.To(() => _titleControl.color, x => _titleControl.color = x, _hoverTextColor, _hoverAnimationDuration))
            .Join(_defaultCanvasGroup.DOFade(0, _hoverAnimationDuration))
            .Join(_hoverCanvasGroup.DOFade(1, _hoverAnimationDuration))
            .Join(DOTween.To(() => _defaultBackgroundImage.fillAmount, x => _defaultBackgroundImage.fillAmount = x, 0, _hoverAnimationDuration))
            .Join(DOTween.To(() => +_hoverBackgroundImage.fillAmount, x => _hoverBackgroundImage.fillAmount = x, 1, _hoverAnimationDuration));
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Sequence exitSequence = DOTween.Sequence();
            exitSequence
            .Append(DOTween.To(() => _titleControl.color, x => _titleControl.color = x, _defaultTextColor, _defaultAnimationDuration))
            .Join(_defaultCanvasGroup.DOFade(1, _defaultAnimationDuration))
            .Join(_hoverCanvasGroup.DOFade(0, _defaultAnimationDuration))
            .Join(DOTween.To(() => _defaultBackgroundImage.fillAmount, x => _defaultBackgroundImage.fillAmount = x, 1, _defaultAnimationDuration))
            .Join(DOTween.To(() => _hoverBackgroundImage.fillAmount, x => _hoverBackgroundImage.fillAmount = x, 0, _defaultAnimationDuration));
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!Input.GetMouseButtonDown(0)) return;

            _callBackAction?.Invoke();

            Sequence clickSequence = DOTween.Sequence();
            clickSequence
            .Append(DOTween.To(() => _titleControl.color, x => _titleControl.color = x, _clickTextColor, _clickAnimationDuration))
            .Join(DOTween.To(() => _hoverBackgroundImage.color, x => _hoverBackgroundImage.color = x, _clickBackgroundColor, _clickAnimationDuration).OnComplete(
                () => { DOTween.To(() => _hoverBackgroundImage.color, x => _hoverBackgroundImage.color = x, _hoverBackgroundColor, _clickAnimationDuration); }
            ))
            .Append(DOTween.To(() => _titleControl.color, x => _titleControl.color = x, _defaultTextColor, _defaultAnimationDuration))
            .Join(_defaultCanvasGroup.DOFade(1, _defaultAnimationDuration))
            .Join(_hoverCanvasGroup.DOFade(0, _defaultAnimationDuration))
            .Join(DOTween.To(() => _defaultBackgroundImage.fillAmount, x => _defaultBackgroundImage.fillAmount = x, 1, _defaultAnimationDuration))
            .Join(DOTween.To(() => _hoverBackgroundImage.fillAmount, x => _hoverBackgroundImage.fillAmount = x, 0, _defaultAnimationDuration));
        }

        /// <summary>
        /// Registers call back action for click event
        /// </summary>
        /// <param name="callBack">Action to register</param>
        public void RegisterCallBack(UnityAction callBack)
        {
            _callBackAction = callBack;
        }
    }
}
