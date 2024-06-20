using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StoryPlayerController_LittleGirl : MonoBehaviour
{
    CharacterController cc;
    Animator anim;
    PlayerInput input;

    private Vector3 _storyMoveInput;

    [Header("Movement")]
    public float _moveSpeed = 10f;
    public float _gravity = 20f;

    float _direction = 1;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();

        anim.SetInteger("Chapter", StoryGameControl_LittleGirl._chapter);

        if (input != null)
        {
            input.enabled = false;
            StartCoroutine(ReEnableInput());
        }
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
        if (isCanMove())
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

    IEnumerator ReEnableInput()
    {
        print("ok1");
        yield return new WaitForSeconds(2f);
        print("ok2");
        input.enabled = true;
    }
}