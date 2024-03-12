using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StoryPlayerController : MonoBehaviour
{
    CharacterController cc;

    private Vector3 _storyMoveInput;

    [Header("Movement")]
    public float _moveSpeed = 10f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _moveSpeed = 18f;
        }
        else
        {
            _moveSpeed = 10f;
        }

        cc.Move(_storyMoveInput * _moveSpeed * Time.fixedDeltaTime);
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        _storyMoveInput = new Vector3(input.x, 0f, input.y);
    }
}
