using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxTouchHandler : MonoBehaviour
{
    public string[] questionScenes = { "try", "try1", "try2" };
    private static int currentQuestionIndex = 0;
    private static string lastSceneName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && currentQuestionIndex < questionScenes.Length)
        {
            lastSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(questionScenes[currentQuestionIndex]);
        }
    }

    public static void ReturnToMainScene(bool answeredCorrectly)
    {
        if (answeredCorrectly)
        {
            currentQuestionIndex++;
        }

        if (!string.IsNullOrEmpty(lastSceneName))
        {
            SceneManager.LoadScene(lastSceneName);
        }
    }
}