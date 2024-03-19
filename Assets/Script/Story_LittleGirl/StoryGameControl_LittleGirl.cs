using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryGameControl_LittleGirl : MonoBehaviour
{
    public static int _task = 0;

    void Update()
    {
        if (_task >= 2)
        {
            SceneManager.LoadScene(1);
        }
    }
}
