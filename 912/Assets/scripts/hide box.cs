using UnityEngine;
using UnityEngine.UI;

public class QuestionBox : MonoBehaviour
{
    public GameObject questionUI; // Reference to the UI panel
    public Text questionText; // Reference to the Text component where the question is displayed
    public string question;
    public string correctAnswer;

    private void OnCollisionEnter(Collision collision)
    {
        // Show the question UI when the player collides with the box
        if (collision.gameObject.CompareTag("Player"))
        {
            questionUI.SetActive(true);
            questionText.text = question;
        }
    }

    public void CheckAnswer(string playerAnswer)
    {
        // Hide the question box if the player answers correctly
        if (playerAnswer.Equals(correctAnswer))
        {
            questionUI.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}