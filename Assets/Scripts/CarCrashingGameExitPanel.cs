using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrashingGameExitPanel : MonoBehaviour
{
    public GameObject _mainMenuPanel, _gameExitPanel;

    public void GameQuit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        _mainMenuPanel.SetActive(true);
        _gameExitPanel.SetActive(false);

    }
}
