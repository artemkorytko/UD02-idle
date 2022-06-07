using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject gamePanel;

    public void SwitchScreens(bool isGameScreen)
    {
        gamePanel.SetActive(isGameScreen);
        mainPanel.SetActive(!isGameScreen);
    }
}
