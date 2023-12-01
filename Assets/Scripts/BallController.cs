using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed;
    private Vector3 goalPosition = new(0, 30, 1000);
    void Start()
    {
        speed = Random.Range(100, 200);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = goalPosition - gameObject.transform.position;
        gameObject.transform.Translate(speed * Time.deltaTime * direction.normalized);
        if (Vector3.Distance(gameObject.transform.position, goalPosition) < 10f)
        {
            Destroy(gameObject);
        }
    }

}