using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerRank : MonoBehaviour
{
    [SerializeField] Text timerText;
    private float timer;
    private bool timeStop;

    void Start()
    {
        timer = 0;
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
            timerText.text = timer.ToString("f2");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeStop = true;
        }
    }
}