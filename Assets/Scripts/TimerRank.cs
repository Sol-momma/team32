using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerRank : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] Text rankText;
    private float timer;
    private bool timeStop;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        if (!timeStop)
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("f2");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeStop = true;
            if (timer <= 2.0f)
            {
                rankText.text = "A";
            }
            else if (timer <= 5.0f)
            {
                rankText.text = "B";
            }
            else
            {
                rankText.text = "C";
            }
        }
    }
}