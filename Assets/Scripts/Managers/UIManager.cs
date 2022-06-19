using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _gamePanel;

    public void SwitchScreens(bool isGameScreen)
    {
        _gamePanel.SetActive(isGameScreen);
        _mainPanel.SetActive(!isGameScreen);
    }
}
