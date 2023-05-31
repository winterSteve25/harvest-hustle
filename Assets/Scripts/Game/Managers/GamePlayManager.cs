using Game.Data;
using UnityEngine;

namespace Game.Managers
{
    public class GamePlayManager : MonoBehaviour
    {
        [SerializeField] private ItemType mushroomSeed;
        
        private void Start()
        {
            MarketManager.Instance.AddSpecialSale(mushroomSeed, 0.1f);
            MarketManager.Instance.AddNormalSale(mushroomSeed);
        }
    }
}