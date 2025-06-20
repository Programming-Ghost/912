using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovment : MonoBehaviour
{
    void Update()
    {
    // حركة اللمس
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float moveX = touch.deltaPosition.x * 0.01f;
                float moveZ = touch.deltaPosition.y * 0.01f;
                transform.Translate(new Vector3(moveX, 0, moveZ));
            }
        }

        // حركة الماوس
        if (Input.GetMouseButton(0)) // الزر الأيسر
        {
            float moveX = Input.GetAxis("Mouse X") * 0.5f;
            float moveZ = Input.GetAxis("Mouse Y") * 0.5f;
            transform.Translate(new Vector3(moveX, 0, moveZ));
        }
    }


}
//yujfgug
