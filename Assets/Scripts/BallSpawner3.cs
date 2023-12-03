using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner3 : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    private int numberOfBalls = 21;


    void Start()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-150f, 150f), Random.Range(30f, 90f), 200);
            Instantiate(ballPrefab, randomPosition, Quaternion.identity);
        }
    }
}
