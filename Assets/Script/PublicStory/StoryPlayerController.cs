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
    public float _gravity = 20f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _moveSpeed = 15f;
        }
        else
        {
            _moveSpeed = 8f;
        }

        if (!cc.isGrounded)
        {
            _storyMoveInput.y -= _gravity * Time.fixedDeltaTime;
        }

        cc.Move(_storyMoveInput * _moveSpeed * Time.fixedDeltaTime);
    }

    void OnMove(InputValue value)
    {
        if (!StoryLittleGirlUIControl.isContentActive)
        {
            Vector2 input = value.Get<Vector2>();
            _storyMoveInput = new Vector3(input.x, 0, input.y);
            print(_storyMoveInput);
        }
        else
        {
            _storyMoveInput = Vector3.zero;
        }
    }
}
