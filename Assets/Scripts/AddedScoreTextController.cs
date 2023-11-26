using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddedScoreTextController : MonoBehaviour
{
    [SerializeField] private Text AddedScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAddedScoreText(int score)
    {
        StartCoroutine(_ShowAddedScoreText(score));
    }

    public IEnumerator _ShowAddedScoreText(int score)
    {
        AddedScoreText.text = "+" + score;
        yield return new WaitForSeconds(1.0f);
        AddedScoreText.text = "";
    }
}
