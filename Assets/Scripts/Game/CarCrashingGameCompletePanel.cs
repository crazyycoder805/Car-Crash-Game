using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class CarCrashingGameCompletePanel : MonoBehaviour
{
    public GameObject _levelsPanel, _loadingPanel;
    public Slider _loadingBar;


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
}
