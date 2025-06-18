using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qustions : MonoBehaviour
{

    private HashSet<int> solvedQuestions = new HashSet<int>();
    private Dictionary<string, List<int>> levelQuestions = new Dictionary<string, List<int>>
    {
        { "level 1", new List<int> { 101, 102, 103, 104, 105 } } // أسئلة المستوى الأول
    };
    private string currentStage = "sa7et ilmadraseh"; // اسم المرحلة الحالية
    private string currentLevel = "level 1"; // المستوى الحالي

    public int GetNewQuestion()
    {
        if (levelQuestions.ContainsKey(currentLevel))
        {
            foreach (int question in levelQuestions[currentLevel])
            {
                if (!solvedQuestions.Contains(question))
                {
                    return question;
                }
            }
        }
        return -1; // كل الأسئلة محلولة
    }

    public void MarkQuestionSolved(int questionId)
    {
        solvedQuestions.Add(questionId);
    }

    public bool AreAllQuestionsSolved()
    {
        return solvedQuestions.Count == levelQuestions[currentLevel].Count;
    }

    public string GetCurrentStage()
    {
        return currentStage;
    }

    public string GetCurrentLevel()
    {
        return currentLevel;
    }
}

