using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class UIGameScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText = null;

        private void Start()
        {
            OnMoneyValueChanged(GameManager.Instance.Money);
            GameManager.Instance.OnMoneyValueChange += OnMoneyValueChanged;
        }

        private void OnMoneyValueChanged(float value)
        {
            _moneyText.text = value.ToString();
        }
    }
}