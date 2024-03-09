using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("CameraMovement")]
    public Transform target;
    public float _smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    float _distance;

    void LateUpdate()
    {
        _distance = Vector3.Distance(transform.position, target.position);
        print(_distance);

        //if ()
        //{
            
        //}
        //else
        //{
            Vector3 _targetPosition = target.position + new Vector3(0f, 7f, -13f);
            transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref velocity, _smoothTime);
        //}
    }
}
