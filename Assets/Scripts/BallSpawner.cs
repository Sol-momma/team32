using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    private float interval = 2f;
    private float minSpeed = 30f;
    private float maxSpeed = 50f;
    private bool isGameOver = false;
    private System.Action GameOver;
    private ObjectPool<GameObject> ballPool;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBall());
        ballPool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(ballPrefab, new Vector3(0, 0, -30), Quaternion.identity),
            actionOnGet: (ball) => ball.SetActive(true),
            actionOnRelease: (ball) => ball.SetActive(false),
            actionOnDestroy: (ball) => Destroy(ball),
            defaultCapacity: 10,
            maxSize: 100);
    }

    public void Initialize(System.Action GameOver)
    {
        this.GameOver = GameOver;
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
            GameObject ball = ballPool.Get();
            ball.transform.position = new Vector3(random_x, y, -30);
            var ballController = ball.GetComponent<BallController>();
            ballController.Initialize(GameOver, (ball) => ballPool.Release(ball));
            ballController.SetSpeed(Random.Range(minSpeed, maxSpeed));
        }
    }

    public void ClearPool()
    {
        ballPool.Clear();
    }


    public void OnGameOver()
    {
        enabled = false;
        isGameOver = true;
    }

    public void OnRestart()
    {
        SetMinSpeed(30f);
        SetMaxSpeed(50f);
        enabled = true;
        isGameOver = false;
    }

    public void SetInterval(float interval)
    {
        this.interval = interval;
    }

    public void SetMinSpeed(float minSpeed)
    {
        this.minSpeed = minSpeed;
    }

    public void IncreaseMinSpeed(float minSpeed)
    {
        this.minSpeed += minSpeed;
    }

    public void SetMaxSpeed(float maxSpeed)
    {
        this.maxSpeed = maxSpeed;
    }

    public void IncreaseMaxSpeed(float maxSpeed)
    {
        this.maxSpeed += maxSpeed;
    }
}
