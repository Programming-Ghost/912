using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string[] questionScenes = { "try", "try1", "try2", "try3", "try4", "try5", "try6", "try7", "try8" };
    private HashSet<string> usedScenes = new HashSet<string>();

    public int correctAnswers = 0;
    public int maxCorrectAnswers = 3;

    private string currentQuestionScene;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // يبقي الكائن بين المشاهد
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextQuestion()
    {
        List<string> available = new List<string>();
        foreach (string scene in questionScenes)
        {
            if (!usedScenes.Contains(scene))
                available.Add(scene);
        }

        if (available.Count == 0)
        {
            Debug.Log("لا توجد أسئلة متبقية!");
            return;
        }

        int index = Random.Range(0, available.Count);
        currentQuestionScene = available[index];
        usedScenes.Add(currentQuestionScene);
        SceneManager.LoadScene(currentQuestionScene);
    }

    public void ReturnToMainScene(bool answeredCorrectly)
    {
        if (answeredCorrectly)
        {
            correctAnswers++;
            Debug.Log("إجابة صحيحة! مجموع الإجابات الصحيحة: " + correctAnswers);
        }
        else
        {
            // إذا كانت إجابة خاطئة، لا نضيف للمستخدم ونبقي المشهد كما هو
            SceneManager.LoadScene(currentQuestionScene);
            return;
        }

        // إذا جاوب بشكل صحيح ورجع للمشهد الرئيسي
        if (correctAnswers >= maxCorrectAnswers)
        {
            Debug.Log("تم حل جميع الأسئلة المطلوبة!");
            // ممكن تضيف شيئًا هنا مثل فتح باب أو فوز المرحلة
        }

        SceneManager.LoadScene("sa7et ilmadraseh");
    }
    public void LoadSpecificQuestion(string sceneName)
    {
        usedScenes.Add(sceneName);
        currentQuestionScene = sceneName;
        SceneManager.LoadScene(sceneName);
    }

    public bool HasUsedScene(string sceneName)
    {
        return usedScenes.Contains(sceneName);
    }

}