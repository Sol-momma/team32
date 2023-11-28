using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    void Update()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
    }
}
