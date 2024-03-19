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
        _fakeLoadingPanel,
        _completePanel,
        _finalCamera,
        _failPanel,
        _loadingPanel,
        _pausePanel,
        _levelsPanel,
        _canvas,
        _carExpAnim,
        _carBody,
        _terrain;

    public GameObject[] _levels, _levelsStartPoint, _levelsOffroad, _levelsStartPointOffroad;
    public Slider _carHealthBar, _loadingBar;

    public Transform[] _terrainPositions;
    public GameObject _brakeBtn;

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
            _levels[PlayerPrefs.GetInt("Level")].SetActive(true);
            _car.transform.position = _levelsStartPoint[PlayerPrefs.GetInt("Level")].transform.position;
            _car.transform.rotation = _levelsStartPoint[PlayerPrefs.GetInt("Level")].transform.rotation;

            _terrain.transform.position = _terrainPositions[PlayerPrefs.GetInt("Level")].position;
        } else if (PlayerPrefs.GetInt("Mode") == 1)
        {
            _levelsOffroad[PlayerPrefs.GetInt("OffroadLevel")].SetActive(true);
            _car.transform.position = _levelsStartPointOffroad[PlayerPrefs.GetInt("OffroadLevel")].transform.position;
            _car.transform.rotation = _levelsStartPointOffroad[PlayerPrefs.GetInt("OffroadLevel")].transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextLevel()
    {
        if (PlayerPrefs.GetInt("Mode") == 0)
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            PlayerPrefs.SetInt("Crashing", PlayerPrefs.GetInt("Crashing") + 1);
        }
        else if (PlayerPrefs.GetInt("Mode") == 1)
        {
            PlayerPrefs.SetInt("OffroadLevel", PlayerPrefs.GetInt("OffroadLevel") + 1);
            PlayerPrefs.SetInt("OffroadCrashing", PlayerPrefs.GetInt("OffroadCrashing") + 1);
        }

        SceneManager.LoadScene(1);
    }

    public void PauseLevel()
    {
        _levelsPanel.SetActive(true);
        _pausePanel.SetActive(true);
        _car.SetActive(false);
        Time.timeScale = 0f;
    }
    public void ResumeLevel()
    {
        _levelsPanel.SetActive(false);

        _pausePanel.SetActive(false);
        _car.SetActive(true);

        Time.timeScale = 1f;
    }


    public void Fail()
    {


        _car.SetActive(false);
        _carCanvas.SetActive(false);
        _carCamera.SetActive(false);
        _finalCamera.SetActive(true);
        _failPanel.SetActive(true);
    }


    public void RetryLevel()
    {
        SceneManager.LoadScene(1);
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
    public void HomeBtn()
    {
        _loadingPanel.SetActive(true);
        StartCoroutine(LoadScreen());

    }
    public IEnumerator LoadScreen()
    {
        AsyncOperation _loadOperation = SceneManager.LoadSceneAsync(0);
        while (!_loadOperation.isDone)
        {
            float _progress = Mathf.Clamp01(_loadOperation.progress / 0.9f);
            _loadingBar.value = _progress;
            yield return null;
        }
    }

}
