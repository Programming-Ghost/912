using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousecamera : MonoBehaviour
{
    float mouseX;
    float mouseY;
    public float mouseSensitivity = 100f;


    public Transform playerBody;


    float rotation = 0f;

    public float minAngle = -90f;
    public float maxAngle = 90f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        rotation -= mouseY;
      rotation =Mathf.Clamp(rotation, minAngle, maxAngle);
        transform.localRotation = Quaternion.Euler(rotation, 0, 0);


         playerBody.Rotate(Vector3.up * mouseX);
    }
}
