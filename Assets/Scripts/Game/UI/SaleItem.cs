using Game.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class SaleItem : MonoBehaviour
    {
        [SerializeField] protected Image icon;
        [SerializeField] protected TMP_Text itemName;
        [SerializeField] protected TMP_Text price;

        public int Price { get; protected set; }

        public ItemType ItemType { get; protected set; }

        public virtual void SetItem(ItemType itemType)
        {
            ItemType = itemType;
            icon.sprite = ItemType.itemIcon;
            itemName.text = ItemType.itemName;
            price.text = "$" + ItemType.price;
            Price = ItemType.price;
        }
    }
}