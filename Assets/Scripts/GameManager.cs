using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
