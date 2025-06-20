using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpener : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the trigger!"); // هاي السطر اللي بدك تشوفه
            if (!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogWarning("اسم المشهد غير معيّن في العنصر: " + gameObject.name);
            }
        }
    }
}
