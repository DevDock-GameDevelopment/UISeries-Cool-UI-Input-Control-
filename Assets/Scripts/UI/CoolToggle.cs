using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace CoolUIElements.Assets.Scripts.UI
{
    public class CoolToggle : MonoBehaviour, IPointerDownHandler
    {

        [Header("Properties")]
        [SerializeField] public string OptionA;
        [SerializeField] public string OptionB;
        [SerializeField] private float _animationDuration = .5f;
        [SerializeField] private bool _isSelected;

        [Header("Controls")]
        [SerializeField] private Transform _imageControl;
        [SerializeField] private CanvasGroup _optionAControl;
        [SerializeField] private CanvasGroup _optionBControl;
        [SerializeField] private TextMeshProUGUI _optionATextControl;
        [SerializeField] private TextMeshProUGUI _optionBTextControl;

        private UnityAction _valueChangeAction;

        private void Awake()
        {
            UpdateSelection();
            _optionATextControl.SetText(OptionA);
            _optionBTextControl.SetText(OptionB);
        }

        private void OnValidate()
        {
            UpdateSelection();
            _optionATextControl.SetText(OptionA);
            _optionBTextControl.SetText(OptionB);
        }

        private void UpdateSelection()
        {
            Sequence optionSequence = DOTween.Sequence();

            if (_isSelected)
            {
                optionSequence
                .Append(_optionAControl.DOFade(0, _animationDuration))
                .Join(_optionBControl.DOFade(1, _animationDuration))
                .Join(_imageControl.DOLocalRotate(new Vector3(0, 0, 180), _animationDuration));
            }
            else
            {
                optionSequence
                .Append(_optionAControl.DOFade(1, _animationDuration))
                .Join(_optionBControl.DOFade(0, _animationDuration))
                .Join(_imageControl.DOLocalRotate(Vector3.zero, _animationDuration));
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isSelected = !_isSelected;

            UpdateSelection();

            _valueChangeAction?.Invoke();
        }

        /// <summary>
        /// Registers action for value change event
        /// </summary>
        /// <param name="valueChangeAction">Action to register for event</param>
        public void RegisterValueChangeAction(UnityAction valueChangeAction)
        {
            _valueChangeAction = valueChangeAction;
        }
    }
}