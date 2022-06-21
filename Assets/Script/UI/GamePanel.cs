using Managers;
using TMPro;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counter;

    private void Start()
    {
        OnMoneyValueChanged(GameManager.Instance.Money);
        GameManager.Instance.OnMoneyValueChange += OnMoneyValueChanged;
    }

    private void OnMoneyValueChanged(float value)
    {
        counter.text = value.ToString();
    }
}
