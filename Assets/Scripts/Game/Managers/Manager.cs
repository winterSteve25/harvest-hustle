using UnityEngine;

namespace Game.Managers
{
    public class Manager<T> : MonoBehaviour where T : Manager<T>
    {
        private static T _instance;
        public static T Instance => _instance;

        protected virtual void Awake()
        {
            _instance = (T) this;
        }
    }
}