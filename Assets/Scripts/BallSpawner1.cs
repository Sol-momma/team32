using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner1 : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    void Start()
    {
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.1f);
            for (int j = 0; j < 7; j++)
            {
                Instantiate(ballPrefab, new Vector3(-90f + 30 * j, 10f + 30 * i, 150f), Quaternion.identity);
            }
        }
    }
}
