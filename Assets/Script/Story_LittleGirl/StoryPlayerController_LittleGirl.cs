using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StoryPlayerController_LittleGirl : MonoBehaviour
{
    CharacterController cc;
    Animator anim;

    private Vector3 _storyMoveInput;

    [Header("Movement")]
    public float _moveSpeed = 10f;
    public float _gravity = 20f;

    float _direction = 1;

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

        anim.SetFloat("Direction", _direction);
        anim.SetInteger("Move", Mathf.RoundToInt(_storyMoveInput.magnitude));
        anim.SetBool("isFire", StoryGameControl_LittleGirl.isUseMatches);

        if (StoryElfControl.isAppear)
        {
            ForceMoveDirection();
        }
    }

    void OnMove(InputValue value)
    {
        if (!StoryLittleGirlUIControl.isContentActive && !StoryGameControl_LittleGirl.isSeeFantasy && !StoryGameControl_LittleGirl.isUseMatchesUI && !TaskController.isTaskActive && !StoryBagControl.isBagActive)
        {
            Vector2 input = value.Get<Vector2>();
            _storyMoveInput = new Vector3(input.x, 0, input.y);
            if (input.x != 0)
            {
                _direction = input.x;
                if (_direction < 0f)
                {
                    _direction = 0f;
                }
            }
        }
    }
    void ForceMoveDirection()
    {
        anim.SetFloat("Direction", 1);
    }
        
}