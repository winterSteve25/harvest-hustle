using System;
using Game.Data;
using Game.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class SpecialSaleItem : SaleItem
    {
        [SerializeField] private TMP_Text percentageOffText;

        private float _percentageOff;

        public override void SetItem(ItemType itemType)
        {
            ItemType = itemType;
            icon.sprite = ItemType.itemIcon;
            itemName.text = ItemType.itemName;
        }

        public void SetPercentageOff(float percentage)
        {
            if (percentage is < 0 or > 1)
            {
                Debug.LogWarning("Tried to set sale percentage off below 0 or above 1");
                return;
            }

            _percentageOff = percentage;
            Price = Mathf.CeilToInt(ItemType.price * (1 - _percentageOff));
            
            price.text = "$" + Price;
            percentageOffText.text = "-" + _percentageOff * 100 + "%";
        }
    }
}