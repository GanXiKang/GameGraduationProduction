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

    [Header("LookBed")]
    public Transform lookBedPoint;
    public static bool isLookBed;

    [Header("LookBookCase")]
    public Transform lookBookCasePoint;
    public static bool isLookBookCase;

    [Header("LookWorkbench")]
    public Transform lookWorkbenchPoint;
    public static bool isLookWorkbench;

    [Header("LookMake")]
    public Transform lookMakePoint;
    public static bool isLookMake;

    public float _moveTime = 2f;
    float _distance;
    float _maxDistance;

    private void Start()
    {
        isFollow = true;
        isLookBed = false;
        isLookBookCase = false;
        isLookWorkbench = false;
        isLookMake = false;

        _maxDistance = 14.5f;
    }

    void LateUpdate()
    {
        _distance = Vector3.Distance(transform.position, target.position);

        //if (transform.position.z <= -20f)
        //{
        //    if (_distance > _maxDistance)
        //    {
        //        isFollow = true;
        //    }
        //    else
        //    {
        //        isFollow = false;
        //    }
        //}
        if (isLookWorkbench)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isLookWorkbench = false;
                isFollow = true;
            }
        }
        CameraMode();
    }

    void CameraMode()
    {
        if (isFollow)
        {
            Vector3 _targetPosition = target.position + new Vector3(0f, 5f, -10f);

            transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref velocity, _smoothTime);
            transform.rotation = Quaternion.Euler(30f, 0f, 0f);
        }

        if (isLookBed)
        {
            transform.position = Vector3.Lerp(transform.position, lookBedPoint.position, _moveTime * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookBedPoint.rotation, _moveTime * Time.deltaTime);
        }

        if (isLookBookCase)
        {
            transform.position = Vector3.Lerp(transform.position, lookBookCasePoint.position, _moveTime * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookBookCasePoint.rotation, _moveTime * Time.deltaTime);
        }

        if (isLookWorkbench)
        {
            transform.position = Vector3.Lerp(transform.position, lookWorkbenchPoint.position, _moveTime * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookWorkbenchPoint.rotation, _moveTime * Time.deltaTime);
        }

        if (isLookMake)
        {
            transform.position = Vector3.Lerp(transform.position, lookMakePoint.position, _moveTime * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookMakePoint.rotation, _moveTime * Time.deltaTime);
        }
    }
}
