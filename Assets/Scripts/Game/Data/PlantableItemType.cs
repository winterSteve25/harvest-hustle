using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "New Plantable Item", menuName = "HarvestHustle/New Plantable Item")]
    public class PlantableItemType : ItemType
    {
        public CropType crop;
    }
}