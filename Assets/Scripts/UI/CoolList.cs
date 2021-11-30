using System.Collections.Generic;
using Cool_UI.Assets.Scripts.Helper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.TMP_Dropdown;

namespace CoolUIElements.Assets.Scripts.UI
{
    public class CoolList : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] public List<OptionData> Items;
        [SerializeField] private GameObject _templateCoolListItem;

        [Header("Controls")]
        [SerializeField] private GameObject _listControl;
        [SerializeField] private Image _imageControl;
        [SerializeField] private TextMeshProUGUI _textControl;

        private void Awake()
        {
            LoadList();
        }

        private void LoadList()
        {
            _listControl.transform.Clear();

            for (int i = 0; i < Items.Count; i++)
            {
                OptionData coolItem = Items[i];
                var newItem = Instantiate(_templateCoolListItem, _listControl.transform);
                var coolListItem = newItem.GetComponent<CoolListItem>();

                coolListItem.SetItem(coolItem.image, coolItem.text);
                coolListItem.RegisterCallBack(() => { 
                    _imageControl.sprite = coolItem.image;
                    _textControl.SetText(coolItem.text);
                    });
            }
        }
    }
}