using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "New Item", menuName = "HarvestHustle/New Item")]
    public class ItemType : ScriptableObject
    {
        public string itemName;
        public Sprite itemIcon;
        public int price;
    }
}