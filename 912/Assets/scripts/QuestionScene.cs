using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionScene : MonoBehaviour
{
    private HashSet<string> solvedQuestions = new HashSet<string>();
    public void MarkQuestionSolved(string questionSceneName)
    {
        solvedQuestions.Add(questionSceneName);
        SceneManager.LoadScene("sa7et ilmadraseh"); // العودة إلى المشهد الرئيسي
    }

    public string questionSceneName;

    public void CorrectAnswerSelected()
    {
        QuestionManager questionManager = FindObjectOfType<QuestionManager>();
        questionManager.MarkQuestionSolved(questionSceneName);
    }

}
