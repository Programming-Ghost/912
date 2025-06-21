using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public static int correctAnswers = 0;
    public Transform targetPoint; // المكان اللي اللاعب لازم يروح له بعد الإجابة
    public float moveSpeed = 3f;
    public string nextSceneName;
    public bool shouldMoveToTarget = false;
    private GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (shouldMoveToTarget && player != null && targetPoint != null)
        {
            player.transform.position = Vector3.MoveTowards(
                player.transform.position,
                targetPoint.position,
                moveSpeed * Time.deltaTime
            );

            // إذا وصل للمكان
            if (Vector3.Distance(player.transform.position, targetPoint.position) < 0.1f)
            {
                shouldMoveToTarget = false;
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }

    public static void RegisterCorrectAnswer()
    {
        correctAnswers++;
        Debug.Log("إجابة صحيحة! العدد: " + correctAnswers);

        // بعد 3 إجابات صحيحة نبدأ الحركة
        if (correctAnswers == 3)
        {
            GameObject manager = GameObject.Find("GameManager");
            if (manager != null)
            {
                manager.GetComponent<QuestionManager>().shouldMoveToTarget = true;
            }

            correctAnswers = 0; // نعيده صفر للمرحلة التالية
        }
    }
}