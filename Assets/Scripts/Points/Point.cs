using UnityEngine;

namespace Points
{
    public class Point : MonoBehaviour
    {
        public void Initialize()
        {
            print("InitializingPoint");
        }
        
        public async void EarnMoney()
        {
            print("MoneyChanged");
        }
        
        public void Upgrade()
        {
            print("Upgrade");
        }
    }
}