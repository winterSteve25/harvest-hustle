using Game.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class InventoryItem : MonoBehaviour
    {
        private ItemStack _itemStack;

        public ItemStack ItemStack
        {
            get => _itemStack;
            set
            {
                _itemStack = value;
                UpdateInfo();
            }
        }

        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text itemName;

        public void UpdateInfo()
        {
            icon.sprite = ItemStack.itemType.itemIcon;
            itemName.text = ItemStack.itemType.itemName + $" x{ItemStack.amount}";
        }
    }
}