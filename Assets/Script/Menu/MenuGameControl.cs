using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameControl : MonoBehaviour
{
    public static bool isNewGameModel = true; //���r��

    public void Start_Button()
    {
        isNewGameModel = true;
        SceneManager.LoadScene(1);
    }
}
