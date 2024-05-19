using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("CameraMovement")]
    public float _smoothTime = 0.5f;
    public static bool isFollow;
    private Vector3 velocity = Vector3.zero;
    GameObject target;

    [Header("LookBed")]
    public Transform lookBedPoint;
    public static bool isLookBed;

    [Header("LookBookCase")]
    public Transform lookBookCasePoint;
    public static bool isLookBookCase;

    [Header("LookStoryWorld")]
    public Transform lookStoryWorldPoint;
    public static bool isLookStoryWorld;

    [Header("LookWorkbench")]
    public Transform lookWorkbenchPoint;
    public static bool isLookWorkbench;

    [Header("LookMake")]
    public Transform lookMakePoint;
    public static bool isLookMake;

    public float _moveTime = 1f;
    float _distance;
    float _maxDistance;

    private void Start()
    {
        target = GameObject.Find("Player");

        isFollow = true;
        isLookBed = false;
        isLookBookCase = false;
        isLookStoryWorld = false;
        isLookWorkbench = false;
        isLookMake = false;

        _maxDistance = 14.5f;
    }

    void LateUpdate()
    {
        _distance = Vector3.Distance(transform.position, target.transform.position);
        CameraMode();
    }

    void CameraMode()
    {
        if (isFollow)
        {
            Vector3 _targetPosition = target.transform.position + new Vector3(0f, 7f, -7f);

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

        if (isLookStoryWorld)
        {
            transform.position = Vector3.Lerp(transform.position, lookStoryWorldPoint.position, _moveTime * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookStoryWorldPoint.rotation, _moveTime * Time.deltaTime);
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
