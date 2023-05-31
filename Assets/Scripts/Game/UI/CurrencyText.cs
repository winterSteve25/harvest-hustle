using Game.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class CurrencyText : MonoBehaviour
    {
        private TMP_Text _text;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            CurrencyManager.Instance.OnCurrencyChanged += UpdateText;
            UpdateText(CurrencyManager.Instance.Currency);
        }

        private void OnDisable()
        {
            CurrencyManager.Instance.OnCurrencyChanged -= UpdateText;
        }

        private void UpdateText(long currency)
        {
            _text.text = currency.ToString();
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform) transform.parent);
        }
    }
}