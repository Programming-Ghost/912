using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public static int correctAnswers = 0;

    [Header("Target Movement Settings")]
    public Transform targetPoint; // المكان الذي يجب على اللاعب الوصول إليه
    public float moveSpeed = 3f;
    public string nextSceneName;

    private GameObject player;
    private bool shouldMoveToTarget = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("لم يتم العثور على لاعب بعلامة 'Player'");
        }
    }

    void Update()
    {
        if (shouldMoveToTarget && player != null && targetPoint != null)
        {
            MovePlayerToTarget();
        }
    }

    void MovePlayerToTarget()
    {
        player.transform.position = Vector3.MoveTowards(
            player.transform.position,
            targetPoint.position,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(player.transform.position, targetPoint.position) < 0.1f)
        {
            shouldMoveToTarget = false;
            SceneManager.LoadScene(nextSceneName);
        }
    }

    public static void RegisterCorrectAnswer()
    {
        correctAnswers++;
        Debug.Log("إجابة صحيحة! العدد: " + correctAnswers);

        if (correctAnswers == 3)
        {
            GameObject manager = GameObject.Find("GameManager");
            if (manager != null)
            {
                QuestionManager qm = manager.GetComponent<QuestionManager>();
                if (qm != null)
                {
                    qm.StartPlayerMovement();
                }
            }
            correctAnswers = 0; // إعادة العداد للمرحلة التالية
        }
    }

    public void StartPlayerMovement()
    {
        shouldMoveToTarget = true;
    }
}
