using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private readonly float speed = 100f;
    private Vector3 goalPosition = new(1000, 0, 1000);
    void Start()
    {
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
