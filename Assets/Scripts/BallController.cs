using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed;
    private Vector3 goalPosition = new(0, 30, 1000);
    void Start()
    {
        if (GameManager.stageNumber == 2)
        {
            speed = Random.Range(100, 200);
        }
    }

    void Update()
    {
        switch (GameManager.stageNumber)
        {
            case 1:
                break;
            case 2:
                Stage2();
                break;
            case 3:
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
}
