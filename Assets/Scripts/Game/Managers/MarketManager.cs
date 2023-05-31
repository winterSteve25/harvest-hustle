using Game.Data;
using Game.UI;
using UnityEngine;

namespace Game.Managers
{
    public class MarketManager : Manager<MarketManager>
    {
        [SerializeField] private Transform specialSalesParent;
        [SerializeField] private Transform normalSalesParent;
        [SerializeField] private SaleItem salePrefab;
        [SerializeField] private SpecialSaleItem specialSalePrefab;

        public void AddSpecialSale(ItemType itemType, float percentageOff)
        {
            var specialSaleItem = Instantiate(specialSalePrefab, specialSalesParent);
            specialSaleItem.SetItem(itemType);
            specialSaleItem.SetPercentageOff(percentageOff);
        }

        public void AddNormalSale(ItemType itemType)
        {
            var normalSaleItem = Instantiate(salePrefab, normalSalesParent);
            normalSaleItem.SetItem(itemType);
        }

        public void BuyItem(SaleItem item)
        {
            InventoryManager.Instance.AddItem(new ItemStack(item.ItemType, 1));
            CurrencyManager.Instance.Currency -= item.Price;
        }
    }
}