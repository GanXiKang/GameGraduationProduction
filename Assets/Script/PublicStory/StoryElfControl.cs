using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElfControl : MonoBehaviour
{
    public static bool isFlyLeave = false;
    float speed = 5f;

    void Update()
    {
        if (isFlyLeave)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            Invoke("DestroyElf", 3f);
        }
    }

    void DestroyElf()
    {
        isFlyLeave = false;
        Destroy(gameObject); 
    }
}
