using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _costText ;
    [SerializeField] private TextMeshProUGUI _text ;

    private Button _button = null;
    private float _intCost = 0;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void OnMoneyValueChanged(float value)
    {
        SetState(value >= _intCost);
    }

    public void SetState(bool state)
    {
        _button.interactable = state;
    }

    public void UpdateButton(string text, float cost)
    {
        _text.text = text;
        _costText.text = cost.ToString();
        _intCost = cost;
    }
}
