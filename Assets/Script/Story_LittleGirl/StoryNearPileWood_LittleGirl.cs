using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryNearPileWood_LittleGirl : MonoBehaviour
{
    public static bool isPileWoodNear = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPileWoodNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPileWoodNear = false;
        }
    }
}
