using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    public string questionSceneName; // اسم المشهد الخاص بالسؤال
    private QustionManegar questionManager;

    private void Start()
    {
        questionManager = FindObjectOfType<QustionManegar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questionManager.OnBoxTouched(questionSceneName);
        }
    }

}
