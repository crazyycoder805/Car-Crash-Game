using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarCrashingDistance : MonoBehaviour
{
    public static CarCrashingDistance _link;
    Vector3 _point;
    GameObject _pointPos;
    public Text _distanceText;

    // Start is called before the first frame update
    void Start()
    {
        _link = this;
    }
    private void OnTriggerExit(Collider _other)
    {
        if (_other.CompareTag("Distance"))
        {
            _point = _other.transform.position;
        }
    }
  
    // Update is called once per frame
    void Update()
    {
        float _distance = Vector3.Distance(transform.position, _point);
        float _distanceCovered = Mathf.Abs(_distance);
        _distanceText.text = _distanceCovered.ToString("F1");

    }


  
}