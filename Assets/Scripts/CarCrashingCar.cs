using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrashingCar : MonoBehaviour
{
    public static CarCrashingCar _link;
    float _health = 1f;
    float _currentHealth;
    public bool _isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        _link = this;
        _currentHealth = _health;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("LevelComplete"))
        {
            _isGrounded = true;
            CarCrashingManager._link._carHealthBar.value = 0f;

            Invoke(nameof(Complete), 2f);
        }
        

        if (!_isGrounded)
        {
            if (_other.CompareTag("Fail"))
            {

                CarCrashingManager._link._levelsPanel.SetActive(true);
                CarCrashingManager._link._car.SetActive(false);
                CarCrashingManager._link._carCanvas.SetActive(false);
                CarCrashingManager._link._carCamera.SetActive(false);
                CarCrashingManager._link._finalCamera.SetActive(true);
                CarCrashingManager._link._failPanel.SetActive(true);
            }
        }
    }
    void Complete()
    {

        CarCrashingManager._link._carExpAnim.SetActive(true);
        //CarCrashingManager._link._carCamera.SetActive(false);


    }
    void OnCollisionEnter(Collision collision)
    {

        //if (!collision.transform.CompareTag("NOT_FAIL"))
        //{
        //    float randomFloat = Random.Range(0.1f, 0.3f);
        //    CarCrashingManager._link._carHealthBar.value -= randomFloat;
        //}

        if (collision.transform.CompareTag("CanCollide"))
        {
            CarCrashingManager._link._carHealthBar.value -= 0.1f;

        }

        if (collision.transform.CompareTag("LevelComplete"))
        {
                _isGrounded = true;
            
                RCC_Settings.Instance.useAutomaticGear = false;
                RCC_Settings.Instance.useAutomaticClutch = false;
                RCC_Settings.Instance.runEngineAtAwake = false;
                RCC_Settings.Instance.autoReverse = false;
                RCC_Settings.Instance.autoReset = false;
                RCC_Settings.Instance.useAutomaticClutch = false;
                CarCrashingManager._link._car.GetComponent<RCC_CarControllerV3>().KillEngine();
                CarCrashingManager._link._brakeBtn.GetComponent<RCC_UIController>().pressing = true;

                Complete();

            
        }


    }





    void OnTriggerExit(Collider _other)
    {
        if (_other.CompareTag("Distance"))
        {
            GetComponent<CarCrashingDistance>().enabled = true;
            CarCrashingDistance._link._distanceText.gameObject.SetActive(true);

        }
    }
}
