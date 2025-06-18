using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
   public string questionSceneName; // اسم المشهد الخاص بالسؤال
    private QuestionManager questionManager;

    private void Start()
    {
        questionManager = FindObjectOfType<QuestionManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questionManager.OnBoxTouched(questionSceneName);
        }
    }
}
