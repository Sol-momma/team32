using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageTextController : MonoBehaviour
{
    private Text stageText;
    private float alpha = 0f;
    private bool isShowing = false;
    // Start is called before the first frame update
    void Start()
    {
        stageText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowing)
        {
            alpha -= Time.deltaTime * 0.5f;
            stageText.color = new Color(0, 0, 0, alpha);
            if (alpha <= 0)
            {
                isShowing = false;
                stageText.text = "";
            }
        }   
    }

    public void ShowStage(int stage)
    {
        alpha = 1f;
        stageText.text = "Stage " + stage;
        stageText.color = new Color(0, 0, 0, alpha);
        isShowing = true;
    }
}
