using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QustionManegar : MonoBehaviour
{
    private HashSet<string> solvedQuestions = new HashSet<string>();

    public void OnBoxTouched(string questionSceneName)
    {
        if (!solvedQuestions.Contains(questionSceneName))
        {
            SceneManager.LoadScene(questionSceneName);
        }
    }

    public void MarkQuestionSolved(string questionSceneName)
    {
        solvedQuestions.Add(questionSceneName);
        SceneManager.LoadScene("sa7et ilmadraseh");
    }

}
