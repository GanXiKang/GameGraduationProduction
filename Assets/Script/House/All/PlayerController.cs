using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CharacterController cc;
    Animator anim;

    private Vector3 _moveInput;
    private Vector3 _lookDirection;

    [Header("Movement")]
    public static bool isNoMove;
    public float _moveSpeed = 10f;
    public float _turnSpeed = 15f;
    float _targetRotation;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (_lookDirection != Vector3.zero)
        {
            _targetRotation = Quaternion.LookRotation(_lookDirection).eulerAngles.y;
            Quaternion _rotation = Quaternion.Euler(0f, _targetRotation, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, _turnSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _moveSpeed = 18f;
        }
        else
        {
            _moveSpeed = 10f;
        }

        if (!GameControl.isNextPlace)
        {
            cc.Move(_moveInput * _moveSpeed * Time.fixedDeltaTime);
        }

        anim.SetFloat("isWalk", _moveInput.magnitude);
    }

    void OnMove(InputValue value)
    {
        if (!CameraController.isLookWorkbench && !UIController.isContentActive && !BedControl.isSleep && !BagController.isBagActive && !GameControl.isOpeningStopMove && !TaskController.isTaskActive && !SettingControl.isSettingActive && !isNoMove)
        {
            Vector2 input = value.Get<Vector2>();
            _moveInput = new Vector3(input.x, 0f, input.y);
            _lookDirection = new Vector3(_moveInput.x, 0f, _moveInput.z).normalized;
        }
        else
        {
            _moveInput = Vector3.zero;
        }
    }
}
