using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GamePanel gamePanelScript;

    private void Awake()
    {
        SwitchScreens(false);
    }

    public void Initialize(GameManager gameManager)
    {
        gameManager.OnMoneyUpdate += gamePanelScript.SetCounter;
    }

    public void SwitchScreens(bool isGameScreen)
    {
        gamePanel.SetActive(isGameScreen);
        mainPanel.SetActive(!isGameScreen);
    }
}
