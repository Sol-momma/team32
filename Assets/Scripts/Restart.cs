using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        // Reload the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }
}

