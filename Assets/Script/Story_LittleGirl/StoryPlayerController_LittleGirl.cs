using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StoryPlayerController_LittleGirl : MonoBehaviour
{
    CharacterController cc;
    PlayerInput input;
    Animator anim;

    private Vector3 _storyMoveInput;

    [Header("Movement")]
    public float _moveSpeed = 10f;
    public float _gravity = 20f;
    float _direction = 1;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();

        anim.SetInteger("Chapter", StoryGameControl_LittleGirl._chapter);

        input.enabled = false;
        Invoke("OpenInputSystemEnable", 1f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _moveSpeed = 12f;
        }
        else
        {
            _moveSpeed = 8f;
        }

        if (!cc.isGrounded)
        {
            _storyMoveInput.y -= _gravity * Time.fixedDeltaTime;
        }

        if (isCanMove())
        {
            cc.Move(_storyMoveInput * _moveSpeed * Time.deltaTime);
        }

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
        if (isCanMove())
        {
            Vector2 input = value.Get<Vector2>();
            _storyMoveInput = new Vector3(input.x, 0f, input.y);
            if (input.x != 0)
            {
                _direction = input.x;
                if (_direction < 0f)
                {
                    _direction = 0f;
                }
            }
        }
        else
        {
            _storyMoveInput = Vector3.zero;
        }
    }
    void ForceMoveDirection()
    {
        anim.SetFloat("Direction", 1);
    }
    void OpenInputSystemEnable()
    {
        input.enabled = true;
    }

    bool isCanMove()
    {
        return !TaskController.isTaskActive &&
               !SettingControl.isSettingActive &&
               !GetItemUIControl.isGetItemActice &&
               !StoryBagControl.isBagActive &&
               !StoryUIControl_LittleGirl.isContentActive &&
               !StoryGameControl_LittleGirl.isSeeFantasy &&
               !StoryGameControl_LittleGirl.isUseMatchesUI;
    }
}