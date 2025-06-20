using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class QuizHandler : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] options = new string[4];
        public int correctIndex;
    }

    public List<Question> stage1Questions;
    public List<Question> stage2Questions;

    public Text questionText;
    public Button[] optionButtons;
    public GameObject[] boxesToActivate; // 4 صناديق للمرحلة
    public GameObject portal;
    public string nextScene = "Library";

    private int currentQuestionIndex = 0;
    private int correctCount = 0;
    private List<Question> currentStage;
    private bool inStageTwo = false;

    void Start()
    {
        currentStage = stage1Questions;
        ShowQuestion();
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex >= currentStage.Count)
        {
            Debug.Log("No more questions!");
            return;
        }

        Question q = currentStage[currentQuestionIndex];
        questionText.text = q.questionText;

        for (int i = 0; i < 4; i++)
        {
            int index = i;
            optionButtons[i].GetComponentInChildren<Text>().text = q.options[i];
            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    void CheckAnswer(int chosen)
    {
        if (currentStage[currentQuestionIndex].correctIndex == chosen)
        {
            Debug.Log("إجابة صحيحة!");
            if (correctCount < boxesToActivate.Length)
                boxesToActivate[correctCount].SetActive(true);

            correctCount++;

            if (correctCount == boxesToActivate.Length)
            {
                if (!inStageTwo)
                    portal.SetActive(true); // تفعيل بوابة المرحلة الثانية
                else
                    Debug.Log("تم إنهاء المرحلة الثانية!"); // هنا ممكن تظهر تهنئة أو شاشة فوز
            }
        }
        else
        {
            Debug.Log("إجابة خاطئة!");
            // يمكن تضيف صوت خطأ أو تحذير بصري أو إعادة السؤال
        }

        currentQuestionIndex++;
        if (currentQuestionIndex < currentStage.Count)
            ShowQuestion();
        else if (!inStageTwo && correctCount >= boxesToActivate.Length)
            Debug.Log("جاهز للانتقال إلى المرحلة الثانية.");
    }

    public void LoadNextStage()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void StartStageTwo()
    {
        currentStage = stage2Questions;
        currentQuestionIndex = 0;
        correctCount = 0;
        inStageTwo = true;

        foreach (GameObject box in boxesToActivate)
            box.SetActive(false);

        portal.SetActive(false);

        ShowQuestion();
    }
}
