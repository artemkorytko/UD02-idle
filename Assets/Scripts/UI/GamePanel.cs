using TMPro;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counter;

    public void SetCounter(float value)
    {
        counter.text = value.ToString();
    }
}
