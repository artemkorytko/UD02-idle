using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UIManager : MonoBehaviour
{
  [SerializeField] private GameObject mainPanel;
  [SerializeField] private GameObject gamePanel;

  private int _game;

  public void SwitchScreens(bool isGameScreen)
  {
      gamePanel.SetActive(isGameScreen);
      mainPanel.SetActive(!isGameScreen);
  }
}
