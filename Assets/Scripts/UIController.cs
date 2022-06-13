using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _mainScreen = null;
    [SerializeField] private GameObject _gameScreen = null;

    public void ShowMainScreen()
    {
        _gameScreen.SetActive(false);
        _mainScreen.SetActive(true);
    }

    public void ShowGameScreen()
    {
        _gameScreen.SetActive(true);
        _mainScreen.SetActive(false);
    }
}
