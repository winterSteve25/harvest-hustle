using System;
using Lib.Serialization;

namespace Game.Data
{
    [Serializable]
    public class ItemStack
    {
        public ItemType itemType;
        public int amount;
        public SerializableData data;

        public ItemStack(ItemType itemType, int amount)
        {
            this.itemType = itemType;
            this.amount = amount;
            data = new SerializableData();
        }

        public bool CanStackWith(ItemStack itemStack)
        {
            return itemStack.itemType == itemType && data == itemStack.data;
        }
    }
}