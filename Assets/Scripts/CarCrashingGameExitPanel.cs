using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrashingGameExitPanel : MonoBehaviour
{
    public void GameQuit()
    {
        Application.Quit();
    }
    public void UITurnOn(GameObject _other)
    {
        _other.SetActive(true);

    }
    public void UITurnOf(GameObject _other)
    {
        _other.SetActive(false);

    }
}
