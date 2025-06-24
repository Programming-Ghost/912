using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    private int correctAnswers = 0;
    public Transform targetPoint;
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

            if (Vector3.Distance(player.transform.position, targetPoint.position) < 0.1f)
            {
                shouldMoveToTarget = false;
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }

    // استدعِ هذه الدالة من سكربت السؤال عند كل إجابة صحيحة
    public void RegisterCorrectAnswer()
    {
        correctAnswers++;
        Debug.Log("إجابة صحيحة! العدد: " + correctAnswers);

        if (correctAnswers == 3)
        {
            shouldMoveToTarget = true;
            correctAnswers = 0;
        }
    }
}
