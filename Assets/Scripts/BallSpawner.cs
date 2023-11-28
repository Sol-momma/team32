using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    private int count = 0;
    private float interval = 2f;
    private float minSpeed = 30f;
    private float maxSpeed = 50f;
    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        while (true)
        {
            yield return new WaitUntil(() => !isGameOver);
            if (interval < 0.1f)
            {
                interval = 0.1f;
            }
            yield return new WaitForSeconds(interval);
            int sign_x = Random.Range(0, 2) * 2 - 1;
            float random_x = sign_x * Random.Range(50f, 150f);
            float y = Random.Range(30f, 90f);
            GameObject ballController = Instantiate(ballPrefab, new Vector3(random_x, y, -30), Quaternion.identity);
            ballController.GetComponent<BallController>().SetSpeed(Random.Range(minSpeed, maxSpeed));
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInterval(float interval)
    {
        this.interval = interval;
    }

    public void SetMinSpeed(float minSpeed)
    {
        this.minSpeed = minSpeed;
    }

    public void IncreaseMinSpped(float minSpeed)
    {
        this.minSpeed += minSpeed;
    }

    public void SetMaxSpeed(float maxSpeed)
    {
        this.maxSpeed = maxSpeed;
    }

    public void IncreaseMaxSpped(float maxSpeed)
    {
        this.maxSpeed += maxSpeed;
    }
}
