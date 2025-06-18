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

        moveDirection = transform.forward * moveZ + transform.right * moveX;
        moveDirection *= currentSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            moveDirection.y = jumpForce;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cardboard Box", "Cardboard Box (1)", "Cardboard Box (2)")) // عند لمس صندوق
        {
            string questionSceneName = other.gameObject.name; // اسم مشهد السؤال
            SceneManager.LoadScene(questionSceneName); // الانتقال إلى المشهد
        }
    }

}
