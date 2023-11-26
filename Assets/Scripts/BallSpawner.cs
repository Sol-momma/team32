using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            float random_x = Random.Range(0f, 200f);
            float random_z = 200f - random_x;
            float y = Random.Range(30f, 90f);
            Instantiate(ballPrefab, new Vector3(random_x, y, random_z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
