using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHitBallCount : MonoBehaviour
{
    [SerializeField] private Text displayText;

    private GameManager gameManager;
    private int hitBallCount;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        hitBallCount = gameManager.hitBallCount;
        int remainingBalls = 63 - hitBallCount;

        if (hitBallCount == 63)
        {
            displayText.text = "残り00個";
        }
        else if (remainingBalls % 21 == 0)
        {
            displayText.text = "残り21個";
        }
        else
        {
            displayText.text = "残り" + (remainingBalls % 21).ToString("00") + "個";
        }
    }
}
