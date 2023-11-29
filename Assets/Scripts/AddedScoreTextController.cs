using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddedScoreTextController : MonoBehaviour
{
    [SerializeField] private Text AddedScoreText;

    public void ShowAddedScore(int score)
    {
        StartCoroutine(_ShowAddedScoreText(score));
    }

    private IEnumerator _ShowAddedScoreText(int score)
    {
        AddedScoreText.text = "+" + score;
        yield return new WaitForSeconds(1.0f);
        AddedScoreText.text = "";
    }
}
