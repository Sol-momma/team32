using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int currentStageScore = 0;
    private int stage = 1;
    private bool isGameOver = false;
    [SerializeField] private ScoreTextContainerController scoreTextContainerController;
    [SerializeField] private StageTextController stageTextController;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private ArrowSpawner arrowSpawner;
    [SerializeField] private GameOverContainerController gameOverContainerController;
    private System.Action b;
    // Start is called before the first frame update
    void Start()
    {
        stageTextController.ShowStage(stage);
        arrowSpawner.Initialize(AddScore);
        ballSpawner.Initialize(GameOver);
        gameOverContainerController.Initialize(Restart);
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
        ballSpawner.IncreaseMaxSpeed(20f);
        ballSpawner.IncreaseMinSpeed(20f);
    }

    private void AddScore(int value)
    {
        score += value;
        currentStageScore += value;
        if (currentStageScore >= 500)
        {
            UpdateStage();
        }
        scoreTextContainerController.ShowScore(score, value);
    }

    private void Restart()
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
        ballSpawner.ClearPool();
        arrowSpawner.ClearPool();
        score = 0;
        currentStageScore = 0;
        stage = 1;
        scoreTextContainerController.ShowScore(score);
        stageTextController.ShowStage(stage);
        isGameOver = false;

        gameOverContainerController.OnRestart();
        cameraController.OnRestart();
        ballSpawner.OnRestart();
        arrowSpawner.OnRestart();
    }

    private void GameOver()
    {
        if (isGameOver)
        {
            return;
        }
        isGameOver = true;
        arrowSpawner.OnGameOver();
        ballSpawner.OnGameOver();
        gameOverContainerController.OnGameOver();
    }
}
