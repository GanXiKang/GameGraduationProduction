using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    AudioSource BGM;
    public AudioClip walk;
    public AudioClip draw;
    public static bool isWalk;
    public static bool isDraw;
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
        if (isDraw)
        {
            if (isPlay)
            {
                BGM.PlayOneShot(draw);
                isPlay = false;
                Invoke("TrueOfisPlay", 0.8f);
            }
        }
    }

    void TrueOfisPlay()
    {
        isPlay = true;
    }
}
