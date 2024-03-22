using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class CarCrashingManager : MonoBehaviour
{
    public static CarCrashingManager _link;
    public GameObject
        _car,
        _carCanvas,
        _carCamera,
        _completePanel,
        _finalCamera,
        _failPanel,
        _levelsPanel,
        _carExpAnim,
        _terrain,_terrainOffroad, _terrainOffroadRoad;

    public GameObject[] _levels, _levelsStartPoint, _levelsOffroad, _levelsStartPointOffroad;
    public Slider _carHealthBar;

    public Transform[] _terrainPositions;
    public GameObject _brakeBtn, _pausePanel;

    void Awake()
    {
        RCC_Settings.Instance.useAutomaticGear = true;
        RCC_Settings.Instance.useAutomaticClutch = true;
        RCC_Settings.Instance.runEngineAtAwake = true;
        RCC_Settings.Instance.autoReverse = true;
        RCC_Settings.Instance.autoReset = true;
        RCC_Settings.Instance.useAutomaticClutch = true;
        _car.GetComponent<RCC_CarControllerV3>().StartEngine();
    }

    // Start is called before the first frame update
    void Start()
    {
        _link = this;
        Time.timeScale = 1f;

       

        if (PlayerPrefs.GetInt("Mode") == 0)
        {
            _terrainOffroad.SetActive(false);
            _terrainOffroadRoad.SetActive(false);
            _terrain.SetActive(true);
            _levels[PlayerPrefs.GetInt("Level")].SetActive(true);
            _car.transform.position = _levelsStartPoint[PlayerPrefs.GetInt("Level")].transform.position;
            _car.transform.rotation = _levelsStartPoint[PlayerPrefs.GetInt("Level")].transform.rotation;

            _terrain.transform.position = _terrainPositions[PlayerPrefs.GetInt("Level")].position;
        } else if (PlayerPrefs.GetInt("Mode") == 1)
        {
            _terrainOffroad.SetActive(true);
            _terrainOffroadRoad.SetActive(true);
            _terrain.SetActive(false);
            _levelsOffroad[PlayerPrefs.GetInt("OffroadLevel")].SetActive(true);
            _car.transform.position = _levelsStartPointOffroad[PlayerPrefs.GetInt("OffroadLevel")].transform.position;
            _car.transform.rotation = _levelsStartPointOffroad[PlayerPrefs.GetInt("OffroadLevel")].transform.rotation;
        }
    }
    public void Fail()
    {


        _car.SetActive(false);
        _carCanvas.SetActive(false);
        _carCamera.SetActive(false);
        _finalCamera.SetActive(true);
        _failPanel.SetActive(true);
    }


    public void PauseLevel()
    {
        _levelsPanel.SetActive(true);
        _pausePanel.SetActive(true);
        _car.SetActive(false);
        Time.timeScale = 0f;
    }
    public void Complete()
    {

        if (CarCrashingCar._link._isGrounded == true)
        {
            _levelsPanel.SetActive(true);
            _car.SetActive(false);
            _carCanvas.SetActive(false);
            _carCamera.SetActive(false);
            _finalCamera.SetActive(true);
            _completePanel.SetActive(true);
        } else
        {
            _levelsPanel.SetActive(true);
            _car.SetActive(false);
            _carCanvas.SetActive(false);
            _carCamera.SetActive(false);
            _finalCamera.SetActive(true);
            _failPanel.SetActive(true);
        }
    }

}
