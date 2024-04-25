using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StoryPlayerController : MonoBehaviour
{
    CharacterController cc;
    Animator anim;

    private Vector3 _storyMoveInput;

    [Header("Movement")]
    public float _moveSpeed = 10f;
    public float _gravity = 20f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        anim.SetInteger("Chapter", StoryGameControl_LittleGirl._chapter);
    }

    void Update()
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

        cc.Move(_storyMoveInput * _moveSpeed * Time.deltaTime);
    }

    void OnMove(InputValue value)
    {
        if (!StoryLittleGirlUIControl.isContentActive)
        {
            Vector2 input = value.Get<Vector2>();
            _storyMoveInput = new Vector3(input.x, 0, input.y);

        }
        else
        {
            _storyMoveInput = Vector3.zero;
        }
        anim.SetInteger("Move", Mathf.RoundToInt(_storyMoveInput.magnitude));
    }
}
