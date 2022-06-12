using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyUI;
    private float _money = 50;

    public float IsMoney
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
        }
    }

    private void Update()
    {
        moneyUI.text = _money.ToString();
    }
}
