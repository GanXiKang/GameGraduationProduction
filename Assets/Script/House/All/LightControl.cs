using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public GameObject night;
    public GameObject daytime;
    public GameObject roof;

    public MeshRenderer catLamp;
    public Material catLamp_Light;
    public Material catLamp_noLight;

    void Update()
    {
        night.SetActive(BedControl.isNight);
        daytime.SetActive(!BedControl.isNight);
        roof.SetActive(BedControl.isNight);

        if (BedControl.isNight)
        {
            catLamp.sharedMaterial = catLamp_Light;
        }
        else
        {
            catLamp.sharedMaterial = catLamp_noLight;
        }
    }
}
