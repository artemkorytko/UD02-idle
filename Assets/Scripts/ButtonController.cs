using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyButton;

    public void UpdateButton(string str, float price)
    {
        moneyButton.text = str + price.ToString();
    }
}
