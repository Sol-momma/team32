using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    public Text resultText;
    private float score; // スコアとして使用するタイムを保持する変数

    void Start()
    {
        // TimerObjectオブジェクトを見つけてタイマーの値を取得
        TimerRank timerRank = GameObject.Find("TimerObject").GetComponent<TimerRank>();
        score = timerRank.GetTime(); // スコアとしてタイムを保持
        resultText.text = "Time: " + timerRank.GetTime().ToString("f2");
    }
    public float GetScore()
    {
        return score; // スコアを取得するメソッド
    }
}
