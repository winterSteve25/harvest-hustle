using System;
using Sirenix.OdinInspector;

namespace Game.Managers
{
    public class CurrencyManager : Manager<CurrencyManager>
    {
        private long _currency;

        [ShowInInspector]
        public long Currency
        {
            get => _currency;
            set
            {
                _currency = value;
                OnCurrencyChanged?.Invoke(_currency);
            }
        }
        
        public event Action<long> OnCurrencyChanged;
    }
}