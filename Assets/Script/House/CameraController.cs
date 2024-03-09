using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("CameraMovement")]
    public Transform target;
    public float _smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 _targetPosition = target.position + new Vector3(0f, 7f, -20f);
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref velocity, _smoothTime);
    }
}
