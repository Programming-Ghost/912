using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace to use SceneManager
public class tlebort : MonoBehaviour
{

    public string scenename;
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Load the scene specified by scenename
            SceneManager.LoadScene("library");
        }
    }
}