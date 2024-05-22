using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsSoundControl : MonoBehaviour
{
    AudioSource BGM;

    void Start()
    {
        BGM = GetComponent<AudioSource>();
    }

    void Update()
    {
        BGM.volume = SettingControl.volumeBGM;
    }
}
