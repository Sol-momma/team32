using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButtonController : MonoBehaviour
{
    private Button restartButton;

    public void Initialize(System.Action OnRestart)
    {
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(() => OnRestart());
    }
}
