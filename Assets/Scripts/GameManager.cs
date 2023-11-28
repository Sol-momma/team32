using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int currentStageScore = 0;
    [SerializeField] private ScoreTextController scoreTextController;
    [SerializeField] private BallSpawner ballSpawnerController;
    [SerializeField] private StageTextController stageTextController;
    private int stage = 1;
    // Start is called before the first frame update
    void Start()
    {
        stageTextController.ShowStage(stage);
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextController.ShowScore(score);
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateStage()
    {
        stage++;
        currentStageScore -= 500;
        stageTextController.ShowStage(stage);
        ballSpawnerController.IncreaseMaxSpped(20f);
        ballSpawnerController.IncreaseMinSpped(20f);
    }

    public void AddScore(int value)
    {
        score += value;
        currentStageScore += value;
        if (currentStageScore >= 500)
        {
            UpdateStage();
        }
    }
}
