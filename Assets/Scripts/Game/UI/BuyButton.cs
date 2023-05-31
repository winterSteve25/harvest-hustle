using Game.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
    public class BuyButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SaleItem saleItem;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            MarketManager.Instance.BuyItem(saleItem);
        }
    }
}