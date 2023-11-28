using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int currentStageScore = 0;
    [SerializeField] private ScoreTextController scoreTextController;
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private StageTextController stageTextController;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private ArrowSpawner arrowSpawner;
    [SerializeField] private GameOverContainerController gameOverContainerController;
    private int stage = 1;
    private bool isGameOver = false;
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
        ballSpawner.IncreaseMaxSpped(20f);
        ballSpawner.IncreaseMinSpped(20f);
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

    public void Restart()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("Arrow");
        foreach (GameObject arrow in arrows)
        {
            Destroy(arrow);
        }
        gameOverContainerController.OnRestart();
        cameraController.Reset();
        score = 0;
        currentStageScore = 0;
        stage = 1;
        stageTextController.ShowStage(stage);
        ballSpawner.SetMinSpeed(30f);
        ballSpawner.SetMaxSpeed(50f);
        ballSpawner.enabled = true;
        ballSpawner.isGameOver = false;
        arrowSpawner.enabled = true;
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }
        arrowSpawner.enabled = false;
        ballSpawner.enabled = false;
        ballSpawner.isGameOver = true;
        gameOverContainerController.OnGameOver();
    }
}
