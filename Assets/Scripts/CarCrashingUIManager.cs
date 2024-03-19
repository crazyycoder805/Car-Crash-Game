using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class CarCrashingUIManager : MonoBehaviour
{
    public static CarCrashingUIManager _link;
    public Slider _loadingBar;
    string _levelSelection;
    Button _btnOpen;

    public GameObject[] _objs;
    int _pref;
    int _index;
    public Text[] _coinsText;
    public GameObject _loadingPanel;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Text _coinText in _coinsText)
        {
            CoinsShow(_coinText);
        }
    }
    void Start()
    {
        _link = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UITurnOn(GameObject _other)
    {
        _other.SetActive(true);

    }
    public void UITurnOf(GameObject _other)
    {
        _other.SetActive(false);

    }


    public void BackBtn(GameObject _btn)
    {

        _btn.gameObject.SetActive(false);


    }
    public void PlayBtn(GameObject _other)
    {
        _other.SetActive(false);
        _objs.FirstOrDefault(_obj => _obj.name == _levelSelection).SetActive(true);
    }
    public void PrefSet(int _prefSet)
    {
        _pref = _prefSet;
    }

    public void StartGameBtn(string _level)
    {
        _objs[2].SetActive(true);
        StartCoroutine(LoadScreen());
        PlayerPrefs.SetInt("Mode", _pref);
        PlayerPrefs.SetInt(_level, _index);

    }

    public void SetIndex(int _indexIn)
    {
        _index = _indexIn;
    }

    public void StartGame(int _index)
    {
        _loadingPanel.SetActive(true);
        PlayerPrefs.SetInt("Mode", 0);

        PlayerPrefs.SetInt("Level", _index);
        StartCoroutine(LoadScreen());
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void LevelSelectionPanel(string _ls)
    {
        _levelSelection = _ls;
    }


    public void ButtonIntractable(Button _btn)
    {
        _btn.interactable = true;
        _btnOpen = _btn;
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



    public void CoinsShow(Text _text)
    {
        _text.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
