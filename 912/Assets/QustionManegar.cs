using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class QuestionManager : MonoBehaviour
{
    public Text questionText; // عنصر `Text UI` لعرض السؤال
    public Button[] answerButtons; // أزرار الإجابات
    private string currentQuestionBox = ""; // اسم الصندوق الحالي
    private HashSet<string> solvedQuestions = new HashSet<string>(); // حفظ الأسئلة المحلولة

    private Dictionary<string, string> boxToQuestion = new Dictionary<string, string>
    {
        { "Cardboard Box", "متى تأسست مدرسة دار العلوم؟" },
        { "Cardboard Box(1)", "من كم طابق تتكون مدرسة دار العلوم؟" },
        { "Cardboard Box(2)", "من كم قسم تتكون مدرسة دار العلوم؟" }
    };

    private Dictionary<string, string[]> boxToAnswers = new Dictionary<string, string[]>
    {
        { "Cardboard Box", new string[] { "1996", "1993" , "1999" ,"1995" } },
        { "Cardboard Box(1)", new string[] { "3", "5", "2", "4" } },
        { "Cardboard Box(2)", new string[] { "5", "1", "2", "3" } }
    };

    private Dictionary<string, int> correctAnswers = new Dictionary<string, int>
    {
        { "Cardboard Box", 1 },
        { "Cardboard Box(1)", 0 },
        { "Cardboard Box(2)", 3 }
    };

    public void OnBoxTouched(string boxName)
    {
        if (!solvedQuestions.Contains(boxName) && boxToQuestion.ContainsKey(boxName))
        {
            currentQuestionBox = boxName;
            DisplayQuestion();
        }
    }

    private void DisplayQuestion()
    {
        if (boxToQuestion.ContainsKey(currentQuestionBox))
        {
            questionText.text = boxToQuestion[currentQuestionBox];

            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<Text>().text = boxToAnswers[currentQuestionBox][i];

                int index = i;
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
            }
        }
    }

    private void CheckAnswer(int selectedIndex)
    {
        if (selectedIndex == correctAnswers[currentQuestionBox])
        {
            Debug.Log("إجابة صحيحة!");
            solvedQuestions.Add(currentQuestionBox); // تسجيل السؤال كـ"محلول"
            questionText.text = "تم حل السؤال! عد إلى الساحة."; // رسالة انتهاء السؤال
        }
        else
        {
            Debug.Log("إجابة خاطئة، حاول مرة أخرى.");
        }
    }

}
