using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Point = System.Drawing.Point;

namespace MyNameSpace
{

    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<Point> _points;
        [SerializeField] private Text moneyCounter;
    
        private int money;

        
        public void Initialize()
        {
            foreach (var point in _points)
            {
                point.Initialize();
            }
        }

   }


    
    
}
