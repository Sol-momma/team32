using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverContainerController : MonoBehaviour
{
    private RestartButtonController restartButtonController;

    public void Initialize(System.Action OnRestart)
    {
        restartButtonController = GetComponentInChildren<RestartButtonController>();
        restartButtonController.Initialize(OnRestart);
    }

    public void OnGameOver()
    {
        gameObject.SetActive(true);
    }

    public void OnRestart()
    {
        gameObject.SetActive(false);
    }
}
