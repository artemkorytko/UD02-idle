using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePanel : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI counter;

    public void Counter(float value)
    {
        counter.text = value.ToString();
    }
}
