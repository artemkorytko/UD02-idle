using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Text buttonText;
    [SerializeField] private Text buttonCost;

    private Button _button;

    public bool IsInteractable => _button.interactable;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void SetInteractable(bool isActive)
    {
        _button.interactable = isActive;
    }

    public void UpdateButtonText(string text, string cost)
    {
        buttonText.text = text;
        buttonCost.text = cost;
    }
}
