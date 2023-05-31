using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "New Crop", menuName = "HarvestHustle/New Crop")]
    public class CropType : ScriptableObject
    {
        public string cropName;
        public Sprite cropIcon;
        public ItemYield[] yields;
        public float maxGrowthProgress;
    }
}