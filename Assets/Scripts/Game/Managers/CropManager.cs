using System.Collections.Generic;
using Game.Data;
using Game.UI;
using UnityEngine;

namespace Game.Managers
{
    public class CropManager : Manager<CropManager>
    {
        [SerializeField] private PlantedCrop plantedCropPrefab;
        [SerializeField] private Transform cropsParent;
        
        private List<PlantedCrop> _instances;
        
        private void Start()
        {
            _instances = new List<PlantedCrop>();
        }

        private void Update()
        {
            foreach (var instance in _instances)
            {
                instance.growthProgress += Time.deltaTime * instance.growthRate;
                instance.UpdateSlider();
                if (instance.growthProgress < instance.type.maxGrowthProgress) continue;
                instance.growthProgress = 0;
                
                foreach (var yield in instance.type.yields)
                {
                    if (!(Random.Range(0, 1f) <= yield.chance)) continue;
                    var baseAmount = Random.Range(yield.minAmount, yield.maxAmount + 1);
                    InventoryManager.Instance.AddItem(new ItemStack(yield.itemType, Mathf.CeilToInt(baseAmount * instance.yieldPercentage)));
                }
            }
        }

        public void Plant(ItemStack itemStack)
        {
            if (itemStack.itemType is not PlantableItemType plantableItemType) return;
            var growthRate = itemStack.data.Get(PlantedCrop.GrowthRateKey).UnwrapOrDefault(1f);
            var yieldPercentage = itemStack.data.Get(PlantedCrop.YieldPercentageKey).UnwrapOrDefault(1f);
            var plantedCrop = Instantiate(plantedCropPrefab, cropsParent);
            plantedCrop.type = plantableItemType.crop;
            plantedCrop.growthRate = growthRate;
            plantedCrop.yieldPercentage = yieldPercentage;
            plantedCrop.Init();
            _instances.Add(plantedCrop);
        }
    }
}