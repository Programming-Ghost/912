using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 5f;          // سرعة اللاعب العادية
    public float sprintSpeed = 8f;    // سرعة اللاعب عند الضغط على Left Shift
    public float jumpForce = 7f;      // قوة القفز
    public float gravity = 9.8f;      // الجاذبية

    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>(); // الحصول على المكون الخاص بتحكم اللاعب
    }

    private void Update()
    {
        isGrounded = controller.isGrounded; // التحقق مما إذا كان اللاعب على الأرض
        
        // الحصول على إدخال الحركة (WASD)
        float moveX = Input.GetAxis("Horizontal"); // ← → (A,D)
        float moveZ = Input.GetAxis("Vertical");   // ↑ ↓ (W,S)

        // تحديد السرعة: عند الضغط على Left Shift، يتم زيادة السرعة
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        // حساب الحركة بناءً على اتجاه اللاعب
        moveDirection = transform.forward * moveZ + transform.right * moveX;
        moveDirection *= currentSpeed;

        // القفز عند الضغط على Space
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            moveDirection.y = jumpForce;
        }

        // تطبيق الجاذبية
        moveDirection.y -= gravity * Time.deltaTime;

        // تحريك اللاعب باستخدام CharacterController
        controller.Move(moveDirection * Time.deltaTime);
    }
}
