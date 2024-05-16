using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    AudioSource BGM;
    public AudioClip walk;
    public static bool isWalk;
    bool isPlay;

    void Start()
    {
        BGM = GetComponent<AudioSource>();

        isPlay = true;
    }

    void Update()
    {
        if (isWalk)
        {
            if (isPlay)
            {
                BGM.PlayOneShot(walk);
                isPlay = false;
                Invoke("TrueOfisPlay", 1f);
            }
        }
    }

    void TrueOfisPlay()
    {
        isPlay = true;
    }
}
