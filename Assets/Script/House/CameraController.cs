using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("CameraMovement")]
    public Transform target;
    public float _smoothTime = 0.5f;
    public static bool isFollow;
    private Vector3 velocity = Vector3.zero;

    [Header("CameraMovement")]
    public Transform lookWorkbenchPoint;
    public static bool isLookWorkbench;

    float _distance;
    float _maxDistance;

    private void Start()
    {
        _maxDistance = 14.5f;
        isFollow = true;
        isLookWorkbench = false;
    }

    void LateUpdate()
    {
        _distance = Vector3.Distance(transform.position, target.position);

        if (transform.position.z <= -20f || transform.position.x <= -20f || transform.position.x >= 20f)
        {
            if (_distance > _maxDistance)
            {
                isFollow = true;
            }
            else
            {
                isFollow = false;
            }
        }

        if(isFollow)
        {
            Vector3 _targetPosition = target.position + new Vector3(0f, 7f, -13f);
            transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref velocity, _smoothTime);
        }

        if (isLookWorkbench)
        {
            transform.position = Vector3.Lerp(transform.position, lookWorkbenchPoint.position, 0.2f);
            print(transform.position);
        }
    }
}
