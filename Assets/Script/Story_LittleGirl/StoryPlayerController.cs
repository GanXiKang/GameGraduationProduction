using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPlayerController : MonoBehaviour
{
    CharacterController cc;

    private Vector3 _moveInput;
    private Vector3 _lookDirection;

    [Header("Movement")]
    public float _moveSpeed = 10f;
    public float _turnSpeed = 15f;
    float _targetRotation;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        _targetRotation = Quaternion.LookRotation(_lookDirection).eulerAngles.y;
        Quaternion _rotation = Quaternion.Euler(0f, _targetRotation, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, _turnSpeed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _moveSpeed = 18f;
        }
        else
        {
            _moveSpeed = 10f;
        }
        cc.Move(_moveInput * _moveSpeed * Time.fixedDeltaTime);
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        _moveInput = new Vector3(input.x, 0f, input.y);
        _lookDirection = new Vector3(_moveInput.x, 0f, _moveInput.z).normalized;
    }
}
