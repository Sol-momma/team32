using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private Text scoreText;

    [SerializeField] private GameObject text;
    [SerializeField] private GameObject[] ballSpawner;
    [SerializeField] private GameObject arrowSpawner;

    public static int hitBallCount = 0;
    public static int stageNumber = 1;

    private void Start()
    {
        for (int i = 0; i < ballSpawner.Length; i++)
        {
            ballSpawner[i].SetActive(false);
        }
        arrowSpawner.SetActive(false);
    }

    void OnScreenClick()
    {
        text.SetActive(false);
        arrowSpawner.SetActive(true);
        ballSpawner[0].SetActive(true);
    }

    void Update()
    {
        if (Input.mousePresent)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnScreenClick();
            }
        }

        scoreText.text = score + "";
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int value)
    {
        score += value;
    }
}
