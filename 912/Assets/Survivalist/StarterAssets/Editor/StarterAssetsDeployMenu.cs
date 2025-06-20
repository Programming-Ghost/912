using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 10f;
    public float sprintSpeed = 13f;
    public float jumpForce = 12f;
    public float gravity = 9.8f;

    private CharacterController controller;
    private Vector3 moveDirection;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        Vector3 direction = transform.forward * moveZ + transform.right * moveX;
        moveDirection.x = direction.x * currentSpeed;
        moveDirection.z = direction.z * currentSpeed;

        if (controller.isGrounded)
        {
            moveDirection.y = -1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cardboard Box")) // ⁄‰œ ·„” ’‰œÊﬁ
        {
            string questionSceneName = other.gameObject.name;
            SceneManager.LoadScene(questionSceneName);
        }
    }
}