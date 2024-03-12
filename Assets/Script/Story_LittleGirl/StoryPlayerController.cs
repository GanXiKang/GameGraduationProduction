using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPlayerController : MonoBehaviour
{
    CharacterController cc;

    public static Vector3 _storyMoveInput;

    [Header("Movement")]
    public float _moveSpeed = 10f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        print(_storyMoveInput);
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
}
