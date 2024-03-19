using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class CarCrashingUIManagerOther : MonoBehaviour
{
    public static CarCrashingUIManagerOther _link;
    public Slider _loadingBar;
    
    public GameObject _loadingPanel;

    // Start is called before the first frame update
    void Start()
    {
        _link = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(int _index)
    {
        _loadingPanel.SetActive(true);
        PlayerPrefs.SetInt("Mode", 1);

        PlayerPrefs.SetInt("OffroadLevel", _index);

        StartCoroutine(LoadScreen());
    }

    public IEnumerator LoadScreen()
    {
        AsyncOperation _loadOperation = SceneManager.LoadSceneAsync(1);
        while (!_loadOperation.isDone)
        {
            float _progress = Mathf.Clamp01(_loadOperation.progress / 0.9f);
            _loadingBar.value = _progress;
            yield return null;
        }
    }


}
