using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CoolUIElements.Assets.Scripts.UI
{
    public class CoolInput : MonoBehaviour
    {
        [Header("Properties")]
        [Tooltip("Properties of the control")]
        [SerializeField] private string _placeHolderText;

        [Header("Colors")]
        [SerializeField] private Color _backgroundColor = Color.black;
        [SerializeField] private Color _fontColor = Color.white;
        [SerializeField] private Color _selectionColor = new Color32(70, 93, 104, 255);
        [SerializeField] private Color _placeHolderColor = new Color32(50, 50, 50, 128);

        [Header("Controls")]
        [SerializeField] private TextMeshProUGUI _inputTextControl;
        [SerializeField] private Image _backgroundImageControl;
        [SerializeField] private TMP_InputField _inputControl;
        [SerializeField] private TextMeshProUGUI _placeHolder;

        private void OnValidate()
        {
            if (_inputTextControl != null)
                _inputTextControl.color = _fontColor;

            if (_backgroundImageControl != null)
                _backgroundImageControl.color = _backgroundColor;

            if (_placeHolder != null)
            {
                _placeHolder.SetText(_placeHolderText);
                _placeHolder.color = _placeHolderColor;
            }

            if (_inputControl != null)
                _inputControl.selectionColor = _selectionColor;
        }
    }
}