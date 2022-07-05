using UnityEngine;

namespace Points
{
    public abstract class Point : MonoBehaviour
    {
        public virtual void Initialize()
        {
            print("InitializingPoint");
        }
        
        public virtual async void EarnMoney()
        {
            print("MoneyChanged");
        }
        
        public virtual void Upgrade()
        {
            print("Upgrade");
        }
    }
}