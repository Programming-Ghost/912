using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gamemanager1 : MonoBehaviour
{

    public Button[] optionButtons;
    public int correctAnswerIndex;
    public string returnSceneName;

    void Start()
    {
        for (int i = 0; i < optionButtons.Length; i++)
        {
            int index = i; // لحل مشكلة الـ Closure
            optionButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    void CheckAnswer(int selectedIndex)
    {
        if (selectedIndex == correctAnswerIndex)
        {
            Debug.Log("إجابة صحيحة!");
            SceneManager.LoadScene(returnSceneName);
        }
        else
        {
            Debug.Log("إجابة خاطئة! جرّب مرة تانية.");
            // بإمكانك هنا تعرض مؤثر صوتي أو رسالة
        }
    }
}
///liuyhjkiughjuyhjuyhjujhn

