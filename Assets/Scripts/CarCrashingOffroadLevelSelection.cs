using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarCrashingOffroadLevelSelection : MonoBehaviour
{
	[SerializeField] List<Button> _levels = new List<Button>();
	public string _pref;


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

	 
    
}
