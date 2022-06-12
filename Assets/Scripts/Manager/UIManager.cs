using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject gamePanel;
    private int _game;

    public void SwitchScreen(bool isGameScreen)
    {
        gamePanel.SetActive(isGameScreen);
        mainPanel.SetActive(!isGameScreen);
    }
}
