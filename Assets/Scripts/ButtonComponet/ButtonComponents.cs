using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonComponents : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI _buttonTextCost;

  private Button _button;

    //public bool IsIntIntereractible => _button.interactable;

    private void Awake() 
    {
        _button = GetComponent<Button>();
    }

    public void IsIntIntereractible(bool isActive)
    {
        _button.interactable = isActive;
    }

    public void UpdateButtonText(string cost)
    {
        _buttonTextCost.text = cost;
    }
}
