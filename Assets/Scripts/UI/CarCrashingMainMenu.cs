using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrashingMainMenu : MonoBehaviour
{
    public GameObject _modeSelectionPanel, _mainMenuPanel, _gameExitPanel; 
  
    public void RaceBtn()
    {
        _mainMenuPanel.SetActive(false);
        _modeSelectionPanel.SetActive(true);
        
    }
    public void ExitPanel()
    {
        _mainMenuPanel.SetActive(false);
        _gameExitPanel.SetActive(true);

    }

}
