using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryControl : MonoBehaviour
{
    static DontDestoryControl instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (StoryGameControl_LittleGirl.isDestoryGameControl)
        {
            Destroy(gameObject);
            StoryGameControl_LittleGirl.isDestoryGameControl = false;
        }
    }
}
