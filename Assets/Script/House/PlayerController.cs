using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CharacterController cc;

    private Vector3 _moveInput;

    [Header("Movement")]
    public float _moveSpeed = 4f;
    public float _turnSpeed = 8f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        cc.Move(_moveInput * _moveSpeed * Time.fixedDeltaTime);
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        _moveInput = new Vector3(input.x, 0f, input.y);
    }
}
