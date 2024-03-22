using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;


public class CarCrashingCarrierLevelSelection : MonoBehaviour
{
	[SerializeField] List<Button> _levels = new List<Button>();
	public string _pref;
	public GameObject _modeSelectionPanel, _nextBtn, _carrierLevelSelectionPanel, _loadingPanel;
	public Slider _loadingBar;
	public void MainMenu()
	{
		_carrierLevelSelectionPanel.SetActive(false);
		_modeSelectionPanel.SetActive(true);

	}
	void OnDisable()
	{
		_nextBtn.SetActive(false);
	}
	void Start()
	{
		if (PlayerPrefs.GetInt(_pref) == 0)
		{
			PlayerPrefs.SetInt(_pref, 1);
		}

		if (_levels.Count > 0)
		{
			foreach (Button btn in _levels)
			{
				btn.interactable = false;
			}


			for (int i = 0; i < (PlayerPrefs.GetInt(_pref)); i++)
			{
				_levels[i].interactable = true;
				_levels[i].transform.GetChild(1).gameObject.SetActive(false);


				if (i == 9)
				{
					break;
				}
			}
		}

	}

	public void LevelSelect(int _index)
	{
		PlayerPrefs.SetInt("Level", _index);
		_nextBtn.SetActive(true);

	}

	public void NextBtn()
	{
		_loadingPanel.SetActive(true);

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
