using System.Collections;
using System.Collections.Generic;
using Points;
using UnityEngine;
using UnityEngine.UI;
using Point = System.Drawing.Point;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<Point> _points;
    [SerializeField] private Text moneyCounter;
    //private Point _currentPoint;
    private int money;


    private void Awake()
    {
        Initialize();
    }


    public void Initialize()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            _points[i]
        }
    }
    
}
