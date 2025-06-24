using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionTracker : MonoBehaviour
{
    private int correctAnswers = 0;
    private int requiredAnswers = 3;

    // «” œ⁄ˆ Â–Â «·œ«·… ⁄‰œ ﬂ· ≈Ã«»… ’ÕÌÕ…
    public void RegisterCorrectAnswer()
    {
        correctAnswers++;

        if (correctAnswers >= requiredAnswers)
        {
            // «·«‰ ﬁ«· «· ·ﬁ«∆Ì ≈·Ï „‘Âœ "library"
            SceneManager.LoadScene("library");
        }
    }
}