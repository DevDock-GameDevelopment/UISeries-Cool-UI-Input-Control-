using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CoolUIElements.Assets.Scripts.UI
{
    public class CoolSlider : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] public int Max;
        [SerializeField] public int Min;
        [SerializeField] public bool DisplayValue;
        [SerializeField] public float Value;

        [Header("Colors")]
        [SerializeField] private Color _backgroundColor = Color.white;
        [SerializeField] private Color _fillColor = Color.white;
        [SerializeField] private Color _handleColor = Color.white;
        [SerializeField] private Color _buttonLeftColor = Color.white;
        [SerializeField] private Color _buttonRightColor = Color.white;

        [Header("Controls")]
        [SerializeField] private Slider _sliderBase;
        [SerializeField] private Image _backgroundControl;
        [SerializeField] private Image _fillControl;
        [SerializeField] private Image _handleControl;
        [SerializeField] private TextMeshProUGUI _valueControl;
        [SerializeField] private Button _buttonRight;
        [SerializeField] private Button _buttonLeft;
        [SerializeField] private Image _buttonRightControl;
        [SerializeField] private Image _buttonLeftControl;
        
        private void Awake()
        {
            _sliderBase.minValue = Min;
            _sliderBase.maxValue = Max;

            _sliderBase.onValueChanged.AddListener(OnSliderValueChanged);
            _buttonRight.onClick.AddListener(ButtonRightClicked);
            _buttonLeft.onClick.AddListener(ButtonLeftClicked);
        }

        private void OnValidate()
        {
            _sliderBase.minValue = Min;
            _sliderBase.maxValue = Max;

            _valueControl.SetText(((int)Value).ToString());
            _valueControl.gameObject.SetActive(DisplayValue);

            _sliderBase.value = Value;
            _sliderBase.SetValueWithoutNotify(Value);

            _backgroundControl.color = _backgroundColor;
            _fillControl.color = _fillColor;
            _handleControl.color = _handleColor;
            _buttonRightControl.color = _buttonRightColor;
            _buttonLeftControl.color = _buttonLeftColor;
        }

        private void OnSliderValueChanged(float value)
        {
            Value = value;

            if (DisplayValue)
                _valueControl.SetText(((int)value).ToString());
        }

        private void ButtonRightClicked()
        {
            if (Value < Max)
            {
                Value += 1;
                _sliderBase.value = Value;
                _sliderBase.SetValueWithoutNotify(Value);
            }
        }

        private void ButtonLeftClicked()
        {
            if (Value > 0)
            {
                Value -= 1;
                _sliderBase.value = Value;
                _sliderBase.SetValueWithoutNotify(Value);
            }
        }

    }
}