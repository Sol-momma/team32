using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextContainerController : MonoBehaviour
{
    private ScoreTextController scoreTextController;
    private AddedScoreTextController addedScoreTextController;
    // Start is called before the first frame update
    void Start()
    {
        scoreTextController = GetComponentInChildren<ScoreTextController>();
        addedScoreTextController = GetComponentInChildren<AddedScoreTextController>();
    }

    public void ShowScore(int score)
    {
        scoreTextController.ShowScore(score);
    }

    public void ShowScore(int score, int addedScore)
    {
        scoreTextController.ShowScore(score);
        addedScoreTextController.ShowAddedScore(addedScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
