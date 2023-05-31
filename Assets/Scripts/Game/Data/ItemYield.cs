using System;
using UnityEngine;

namespace Game.Data
{
    [Serializable]
    public struct ItemYield
    {
        public ItemType itemType;
        public int minAmount;
        public int maxAmount;
        
        [Range(0, 1)]
        public float chance;
    }
}