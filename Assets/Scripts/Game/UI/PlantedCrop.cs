using System;
using DG.Tweening;
using Game.Data;
using Lib.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class PlantedCrop : MonoBehaviour
    {
        public static IDataKey<float> GrowthRateKey = new DataKey<float>("CropGrowthRate");
        public static IDataKey<float> YieldPercentageKey = new DataKey<float>("CropYieldPercentage");
        
        [SerializeField] private Image cropImage;
        [SerializeField] private TMP_Text cropName;
        [SerializeField] private Slider slider;
        
        public CropType type;
        public float growthRate;
        public float yieldPercentage;
        public float growthProgress;

        public void Init()
        {
            cropImage.sprite = type.cropIcon;
            cropName.text = type.cropName;
        }

        public void UpdateSlider()
        {
            slider.DOValue(growthProgress, 0.1f)
                .SetEase(Ease.InOutCubic);
        }
    }
}