using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButtonController : MonoBehaviour
{
    private Button restartButton;
    // Start is called before the first frame update
    void Start()
    {
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(Restart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        var gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.Restart();
    }
}
