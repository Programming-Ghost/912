using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // أو بالرقم (index)
    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
