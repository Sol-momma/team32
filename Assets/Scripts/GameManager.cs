using System.Collections;
using System.Collections.Generic;
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

    private bool isClicked = true;
    private bool isStage2 = true;
    private bool isStage3 = true;
    [SerializeField] private GameObject[] text;
    [SerializeField] private GameObject[] ballSpawner;
    [SerializeField] private GameObject arrowSpawner;

    public int hitBallCount = 0;
    public int stageNumber = 0;
    public int ballNum = 21;

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
        arrowSpawner.SetActive(true);

        Destroy(text[stageNumber]);
        ballSpawner[stageNumber].SetActive(true);
        isClicked = false;

        timerRank.StartTimer(); // タイマーを開始
  
    }

    void Update()
    {
        if (Input.mousePresent && isClicked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnScreenClick();
            }
        }

        if (hitBallCount >= ballNum * 2 && isStage3)
        {
            arrowSpawner.SetActive(false);
            isClicked = true;
            Stage3();
        }
        else if (hitBallCount >= ballNum && isStage2)
        {
            arrowSpawner.SetActive(false);
            isClicked = true;
            Stage2();
        }

        scoreText.text = score + "";
    }

    private void Stage3()
    {
        stageNumber = 2;
        DestroyAllBalls();
        ballSpawner[1].SetActive(false);
        arrowSpawner.SetActive(false);
        text[2].SetActive(true);
        isStage3 = false;
    }

    private void Stage2()
    {
        stageNumber = 1;
        ballSpawner[0].SetActive(false);
        arrowSpawner.SetActive(false);
        text[1].SetActive(true);
        isStage2 = false;
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int value)
    {
        score += value;
    }


    public void BallHit()
    {
        hitBallCount++;
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
