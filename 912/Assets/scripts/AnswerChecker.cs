using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnswerChecker : MonoBehaviour
{
    public bool isCorrect = false;
    public Text feedbackText;

    // اسم المشهد الرئيسي
    public string returnScene = "sa7et ilmadraseh";

    void Start()
    {
        feedbackText.text = "";
    }

    public void CheckAnswer()
    {
        if (isCorrect)
        {
            feedbackText.text = "✔️ إجابة صحيحة!";
            feedbackText.color = Color.green;

            // خزّن عدد الإجابات الصحيحة مؤقتًا
            int currentScore = PlayerPrefs.GetInt("CorrectCount", 0);
            PlayerPrefs.SetInt("CorrectCount", currentScore + 1);
        }
        else
        {
            feedbackText.text = "❌ إجابة خاطئة!";
            feedbackText.color = Color.red;
        }

        Invoke("ReturnToMainScene", 2f); // انتظر ثانيتين ثم ارجع للمشهد
    }

    void ReturnToMainScene()
    {
        SceneManager.LoadScene(returnScene);
    }
}
//gfhiuyfdguytfdhytfvhg