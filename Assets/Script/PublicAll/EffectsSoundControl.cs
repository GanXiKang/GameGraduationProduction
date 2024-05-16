using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsSoundControl : MonoBehaviour
{
    AudioSource BGM;

    void Update()
    {
        BGM.volume = SettingControl.volumeBGM;
    }
}
