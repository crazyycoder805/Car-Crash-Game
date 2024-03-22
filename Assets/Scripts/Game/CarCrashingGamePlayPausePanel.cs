using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class CarCrashingGamePlayPausePanel : MonoBehaviour
{
    public GameObject _levelsPanel, _pausePanel, _car, _loadingPanel;
    public Slider _loadingBar;
   
    public void ResumeLevel()
    {
        _levelsPanel.SetActive(false);

        _pausePanel.SetActive(false);
        _car.SetActive(true);

        Time.timeScale = 1f;
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
    public void RetryLevel()
    {
        SceneManager.LoadScene(1);
    }

}
