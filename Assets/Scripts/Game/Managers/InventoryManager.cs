using System.Collections.Generic;
using System.Linq;
using Game.Data;
using Game.UI;
using UnityEngine;

namespace Game.Managers
{
    public class InventoryManager : Manager<InventoryManager>
    {
        [SerializeField] private Transform itemsParent;
        [SerializeField] private InventoryItem itemPrefab;
        
        private List<InventoryItem> _items;
        private List<ItemStack> _plantableItems;

        private void Start()
        {
            _items ??= new List<InventoryItem>();
        }

        public void AddItem(ItemStack itemStack)
        {
            if (_items.Any(i => i.ItemStack.CanStackWith(itemStack)))
            {
                var index = _items.FindIndex(i => i.ItemStack.CanStackWith(itemStack));
                var item = _items[index];
                item.ItemStack.amount += itemStack.amount;
                item.UpdateInfo();
                return;
            }
            
            var inventoryItem = Instantiate(itemPrefab, itemsParent);
            inventoryItem.ItemStack = itemStack;
            _items.Add(inventoryItem);
            _plantableItems = InternalGetPlantableItems();
        }

        public void AddItem(List<ItemStack> itemstacks)
        {
            foreach (var itemstack in itemstacks)
            {
                AddItem(itemstack);
            }
        }

        public List<ItemStack> GetPlantableItems()
        {
            return _plantableItems ??= InternalGetPlantableItems();
        }

        private List<ItemStack> InternalGetPlantableItems()
        {
            return _items
                .Where(s => s.ItemStack.itemType is PlantableItemType)
                .Select(s => s.ItemStack)
                .ToList();
        }
    }
}