using UnityEngine;
using UnityEngine.UI; // 追加

public class ResultScreen : MonoBehaviour
{
    public Text resultText;

    void Start()
    {
        // TimerObjectオブジェクトを見つけてタイマーの値を取得
        TimerRank timerRank = GameObject.Find("TimerObject").GetComponent<TimerRank>();
        resultText.text = "Time: " + timerRank.GetTime().ToString("f2");
    }
}
