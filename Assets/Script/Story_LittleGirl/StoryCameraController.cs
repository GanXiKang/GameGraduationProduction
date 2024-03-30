using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryCameraController : MonoBehaviour
{
    [Header("CameraMovement")]
    public Transform target;
    public float _smoothTime = 0.5f;
    public static bool isFollow;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        isFollow = true;
    }
    
    void LateUpdate()
    {
        if (isFollow)
        {
            Vector3 _targetPosition = target.position + new Vector3(0f, 6f, -10f);
            print("4:" + target.position);
            transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref velocity, _smoothTime);
            transform.rotation = Quaternion.Euler(30f, 0f, 0f);
        }
    }
}
