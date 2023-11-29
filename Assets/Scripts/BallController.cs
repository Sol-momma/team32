using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed = 0;
    private Vector3 goalPosition = new(0, 30, 1000);
    private System.Action GameOver;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = goalPosition - gameObject.transform.position;
        gameObject.transform.Translate(speed * Time.deltaTime * direction.normalized);
        if (Vector3.Distance(gameObject.transform.position, goalPosition) < 10f)
        {
            GameOver();
            Destroy(gameObject);
        }
    }

    public void Initialize(System.Action GameOver)
    {  
        this.GameOver = GameOver;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
        if (speed > 1200f)
        {
            this.speed = 1200f;
        }
    }

}
