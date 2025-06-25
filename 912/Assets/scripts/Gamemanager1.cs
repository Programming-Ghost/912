using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager1 : MonoBehaviour
{
    [Header("Option Buttons")]
    public Button[] optionButtons;      // مصفوفة ديناميكية بأي عدد
    [Tooltip("Index (0-based) of the correct button in optionButtons")]
    public int correctOptionIndex;      

    [Header("Next Scene")]
    public string nextSceneName;        // اسم المشهد الهدف

    void Start()
    {
        // اربط لكل زر حدث الضغط
        for (int i = 0; i < optionButtons.Length; i++)
        {
            int idx = i;  // عشان الكلوجر
            optionButtons[i].onClick.AddListener(() => OnOptionSelected(idx));
        }
    }

    void OnOptionSelected(int index)
    {
        if (index == correctOptionIndex)
        {
            // إجابة صحيحة → انتقل للمشهد التالي
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            // إجابة خاطئة → تعامل حسب ما بدك
            Debug.Log("اختيار خاطئ، حاول مرة ثانية.");
        }
    }
}