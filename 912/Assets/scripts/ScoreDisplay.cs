using UnityEngine;
using UnityEngine.UI; // أو using TMPro; إذا كنت تستخدم TextMeshPro

public class ScoreDisplay : MonoBehaviour
{
    public Text yourUIText; // أو TextMeshProUGUI لو تستخدم TMP

    void Start()
    {
        int score = PlayerPrefs.GetInt("CorrectCount", 0);
        yourUIText.text = score + " / 3";
    }
}
