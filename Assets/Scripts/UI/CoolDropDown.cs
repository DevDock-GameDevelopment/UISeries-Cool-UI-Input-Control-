using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TMPro.TMP_Dropdown;

namespace CoolUIElements.Assets.Scripts.UI
{
    public class CoolDropDown : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] public List<OptionData> Options;
        [SerializeField] public string Selected;
        [SerializeField] public int SelectedIndex;

        private TMP_Dropdown _dropDownControl;

        void Start()
        {
            _dropDownControl = GetComponent<TMP_Dropdown>();
            _dropDownControl.options = Options;

            _dropDownControl.onValueChanged.AddListener(DropDownMenuValueChanged);
        }

        private void DropDownMenuValueChanged(int index)
        {
            Selected = Options[index].text;
            SelectedIndex = index;
        }

        /// <summary>
        /// Sets options for dropdown menu
        /// </summary>
        /// <param name="options">Options to set</param>
        public void SetOptions(List<OptionData> options)
        {
            Options = options;
            _dropDownControl.options = Options;
        }

    }
}