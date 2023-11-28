using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverContainerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameOver()
    {
        gameObject.SetActive(true);
    }

    public void OnRestart()
    {
        gameObject.SetActive(false);
    }
}
