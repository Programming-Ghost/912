using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTouch : MonoBehaviour
{
    public string sceneToLoad; // نحدد اسم المشهد المطلوب لكل صندوق

    void OnMouseDown()
    {
        if (GameManager.Instance.HasUsedScene(sceneToLoad))
        {
            Debug.Log("لقد قمت بحل هذا السؤال مسبقًا.");
            return;
        }

        GameManager.Instance.LoadSpecificQuestion(sceneToLoad);
    }
}
