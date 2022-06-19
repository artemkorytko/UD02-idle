using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _costText = null;
    [SerializeField] private TextMeshProUGUI _text = null;

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
