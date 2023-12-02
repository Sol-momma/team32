using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour
{
    private float speed;
    private Vector3 goalPosition = new(0, 30, 1000);
    private Vector3 moveDirection;
    private float changeDirectionInterval = 2f;
    private float timer = 0f;

    void Start()
    {
        if (GameManager.stageNumber == 1)
        {
            speed = Random.Range(100, 180);
        }

        if (GameManager.stageNumber == 2)
        {
            speed = Random.Range(50, 100);
            ChangeDirection();
        }
    }

    void Update()
    {
        switch (GameManager.stageNumber)
        {
            case 0:
                break;
            case 1:
                Stage2();
                break;
            case 2:
                Stage3();
                break;
            default:
                break;
        }
    }

    void Stage2()
    {
        Vector3 direction = goalPosition - gameObject.transform.position;
        gameObject.transform.Translate(speed * Time.deltaTime * direction.normalized);
        if (Vector3.Distance(gameObject.transform.position, goalPosition) < 10f)
        {
            Destroy(gameObject);
        }
    }

    void Stage3()
    {
        timer += Time.deltaTime;
        if (timer > changeDirectionInterval)
        {
            ChangeDirection();
            timer = 0f;
        }

        Vector3 newPosition = transform.position + moveDirection * speed * Time.deltaTime;

        // 画面の範囲内に収める
        if (Mathf.Abs(newPosition.x) > 100 || newPosition.y < 10f || newPosition.y > 90f
            || newPosition.z < 200f || newPosition.z > 400f)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -100f, 100f),
                Mathf.Clamp(transform.position.y, 10f, 90f),
                Mathf.Clamp(transform.position.z, 200f, 400f)
            );
            moveDirection = -moveDirection;
        }
        else
        {
            gameObject.transform.Translate(speed * Time.deltaTime * moveDirection);
        }
    }

    private void ChangeDirection()
    {
        moveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
