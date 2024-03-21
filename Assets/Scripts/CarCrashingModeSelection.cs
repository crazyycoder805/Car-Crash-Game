using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarCrashingModeSelection : MonoBehaviour
{
    public GameObject _modeSelectionPanel, _mainMenuPanel, _nextBtn, _carrierLevelSelectionPanel, _offroadLevelSelectionPanel;
    public Text _carrierLevelText, _offroadLevelText;

    void Start()
    {
        TotalCarrierLevelsViewer();
        TotalOffroadLevelsViewer();
    }
    public void MainMenu()
    {
        _mainMenuPanel.SetActive(true);
        _modeSelectionPanel.SetActive(false);

    }
    void OnDisable()
    {
        _nextBtn.SetActive(false);
    }

    public void ModeSelect(int _index)
    {
        PlayerPrefs.SetInt("Mode", _index);
        _nextBtn.SetActive(true);

    }

    public void NextBtn()
    {
        _modeSelectionPanel.SetActive(false);
        if (PlayerPrefs.GetInt("Mode") == 0)
        {
            _offroadLevelSelectionPanel.SetActive(false);
            _carrierLevelSelectionPanel.SetActive(true);

        }
        else if (PlayerPrefs.GetInt("Mode") == 1)
        {
            _carrierLevelSelectionPanel.SetActive(false);
            _offroadLevelSelectionPanel.SetActive(true);
        }

    }


    public void TotalCarrierLevelsViewer()
    {
        _carrierLevelText.text = "10" + "/" + PlayerPrefs.GetInt("Crashing").ToString();
    }
    public void TotalOffroadLevelsViewer()
    {
        _offroadLevelText.text = "10" + "/" + PlayerPrefs.GetInt("OffroadCrashing").ToString();
    }
}
