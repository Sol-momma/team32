using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerRank : MonoBehaviour
{
    public static TimerRank Instance { get; private set; }
    [SerializeField] Text timerText;
    public float timer;
    private bool timeStop;
    public bool startTimer; // タイマーを開始するためのフラグ
    public Text resultText; // 結果を表示するためのTextオブジェクトをInspectorからアタッチ

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        
    }
    public void StopTimer()
    {
        timeStop = true;
    }

    void Update()
    {
        if (!timeStop && startTimer) // startTimerフラグがtrueのときだけタイマーを更新
        {
            timer += Time.deltaTime;
            if (timerText != null) // timerTextがnullでないことを確認
            {
                timerText.text = timer.ToString("f2");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeStop = true;
        }
    }
    public float GetTime()
    {
        return timer;
    }
    // タイマーの開始を制御するためのメソッド
    public void StartTimer()
    {
        startTimer = true;
    }
}