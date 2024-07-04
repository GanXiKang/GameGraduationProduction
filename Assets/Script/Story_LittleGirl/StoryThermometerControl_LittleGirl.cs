using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryThermometerControl_LittleGirl : MonoBehaviour
{
    public static bool isThermometer = true;
    public static bool isDead;
    float _temperature;
    float _decline;
    float _rise;

    [Header("UI")]
    public GameObject thermometerUI;
    public Image energyBar;

    void Start()
    {
        _temperature = 36.5f;
        _decline = 0.1f;
        _rise = 0.15f;
    }

    void Update()
    {
        thermometerUI.SetActive(isThermometer);
        energyBar.fillAmount = (_temperature - 35f) / 2;

        if (isThermometer)
        {
            if (!StoryGameControl_LittleGirl.isUseMatches)
            {
                _temperature -= _decline * Time.deltaTime;
            }
            else 
            {
                _temperature += _rise * Time.deltaTime;
            }
        }

        Limit();
    }

    void Limit()
    {
        if (_temperature >= 37.0f)
        {
            _temperature = 37.0f;
        }

        if (_temperature <= 35.0f)
        {
            _temperature = 35.0f;
            isDead = true;
        }
    }
}
