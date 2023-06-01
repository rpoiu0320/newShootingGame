using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

// Transform, Rigidbody, Character controller �� ��Ȳ�� �°� ������Ʈ�� �̵� ����

public class PlayerMover : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;
    private Vector3 moveDir;
    private float ySpeed = 0;
    private float moveSpeed = 0;
    private bool isWarking;

    [SerializeField] private float runSpeed;
    [SerializeField] private float warkSpeed;
    [SerializeField] private float JumpSpeed;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        // ������� ������
        // controller.Move(moveDir * moveSpeed * Time.deltaTime); 

        if(moveDir.magnitude == 0)      // �ȿ�����
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, 0.25f);   // ��������
        }
        else if(isWarking)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, warkSpeed, 0.25f);
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, runSpeed, 0.25f);
        }

        // ���ñ��� ������
        controller.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);
        controller.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);

        animator.SetFloat("XSpeed", moveDir.x, 0.25f, Time.deltaTime);
        animator.SetFloat("YSpeed", moveDir.z, 0.25f, Time.deltaTime);
        animator.SetFloat("Speed", moveSpeed);
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDir = new Vector3(input.x, 0, input.y);
    }

    private void Jump()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;

        /* if(characterController.isGrounded)   // isGrounded�� �������� �ʾ� ����� ��õ���� ����
            ySpeed = 0;
        */

        if (GroundCheck() && ySpeed < 0)
            ySpeed = -1;

        // if(GroundCheck())
            controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void OnJump(InputValue value)
    {
        if (GroundCheck())
            ySpeed = JumpSpeed;
    }

    private bool GroundCheck()
    {
        RaycastHit hit; // 2D�� 3D�� ��¦ �ٸ�
        return Physics.SphereCast(transform.position + Vector3.up * 1, 0.5f, Vector3.down, out hit, 0.6f);
        //                          �� ��ġ,                         ��� �ѷ�,  ��� ����,   out �Ķ����, ��� ����
    }

    private void OnWork(InputValue value)
    {
        isWarking = value.isPressed;
    }
}
