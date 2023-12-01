using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerRank : MonoBehaviour
{
    [SerializeField] Text timerText;
    public float timer;
    private bool timeStop;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        timer = 0;
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
        if (!timeStop)
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
}