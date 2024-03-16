using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColliderControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("yes");
        }
    }
}
