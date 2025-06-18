using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionScene : MonoBehaviour
{
    public string questionSceneName;

    public void CorrectAnswerSelected()
    {
        QuestionManager questionManager = FindObjectOfType<QuestionManager>();
        questionManager.MarkQuestionSolved(questionSceneName);
    }

}
