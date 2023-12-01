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
    public int collisionCount = 0; // 衝突回数をカウントする変数を追加
    public bool isGameActive = true; // isGameActiveをtrueに初期設定
    public TimerRank timerRank; // TimerRankへの参照を追加
    // Start is called before the first frame update

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
        timerRank.StartTimer(); // タイマーを開始
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
    public void DestroyAllBalls() // すべてのボールを消去する新しいメソッド
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
    }
}
