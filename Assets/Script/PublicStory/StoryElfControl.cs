using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElfControl : MonoBehaviour
{
    Animator anim;

    public Transform appearPoint;

    public static bool isAppear = false;
    public static bool isFlyLeave = false;

    float speed = 5f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isAppear)
        {
            isAppear = false;
            transform.position = appearPoint.position;
        }
        if (isFlyLeave)
        {
            anim.SetBool("isFlyLeave", isFlyLeave);
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
