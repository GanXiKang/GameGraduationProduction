using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryArrowTipControl_LittleGirl : MonoBehaviour
{
    float speed = 0.5f;
    Vector3 startPos;
    Vector3 endPos;
    bool isMoveUp;

    public static bool isDestory = false;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(0, 0.8f, 0);
        isMoveUp = true;
    }

    void Update()
    {
        if (!isDestory)
        {
            if (isMoveUp)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
                if (transform.position == endPos)
                {
                    isMoveUp = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
                if (transform.position == startPos)
                {
                    isMoveUp = true;
                }
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
