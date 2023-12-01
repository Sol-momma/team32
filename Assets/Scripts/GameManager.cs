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
    public void DestroyAllBalls() // すべてのボールを消去する新しいメソッド
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
    }
}
