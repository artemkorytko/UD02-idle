using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private GameObject gamePanel;

        public void SwitchScreen(bool isGameScreen)
        {
            gamePanel.SetActive(isGameScreen);
            mainPanel.SetActive(isGameScreen);
        }
    }
}

