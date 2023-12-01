using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerRank : MonoBehaviour
{
    [SerializeField] Text timerText;
    public float timer;
    private bool timeStop;
    public bool startTimer; // タイマーを開始するためのフラグ

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        timer = 0;
        startTimer = false; // 初期状態ではタイマーは開始しない
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