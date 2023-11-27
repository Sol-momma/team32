using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    private int count = 0;
    private float interval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        while (true)
        {
            interval = 2f / (count / 10f + 1);
            if (interval < 0.1f)
            {
                interval = 0.1f;
            }
            yield return new WaitForSeconds(interval);
            int sign_x = Random.Range(0, 2) * 2 - 1;
            float random_x = sign_x * Random.Range(50f, 150f);
            float y = Random.Range(30f, 90f);
            GameObject ballController = Instantiate(ballPrefab, new Vector3(random_x, y, -100), Quaternion.identity);
            ballController.GetComponent<BallController>().SetSpeed(Random.Range(100f, 200f) + count * 10);
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
