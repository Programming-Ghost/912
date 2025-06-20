using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] options = new string[4];
        public int correctIndex;
    }

    public List<Question> allQuestions;
    public Text questionText;
    public Button[] optionButtons;
    public GameObject[] boxesToShow;
    public string nextSceneName;
    private int currentQuestion = 0;
    private int correctAnswers = 0;

    void Start()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        if (currentQuestion < allQuestions.Count)
        {
            Question q = allQuestions[currentQuestion];
            questionText.text = q.questionText;

            for (int i = 0; i < 4; i++)
            {
                int index = i;
                optionButtons[i].GetComponentInChildren<Text>().text = q.options[i];
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => CheckAnswer(index));
            }
        }
        else
        {
            // جميع الأسئلة انتهت، يمكن تفعيل الانتقال
            if (correctAnswers >= 4 && !string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }

    void CheckAnswer(int chosenIndex)
    {
        if (chosenIndex == allQuestions[currentQuestion].correctIndex)
        {
            if (correctAnswers < boxesToShow.Length)
                boxesToShow[correctAnswers].SetActive(true);

            correctAnswers++;
        }

        currentQuestion++;
        ShowQuestion();
    }
}
