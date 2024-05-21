using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBookQuizControl : MonoBehaviour
{
    public GameObject storyQuiz;

    void Start()
    {
        Invoke("WaitOpenBookAnim", 2.4f);
        print("OK");
    }

    void WaitOpenBookAnim()
    {
        storyQuiz.SetActive(true);
    }
}
