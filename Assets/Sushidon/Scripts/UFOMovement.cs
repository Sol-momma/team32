using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float changeDirectionInterval = 3f;

    private float timeSinceLastDirectionChange;
    private Vector3 direction;

    private void Start()
    {
        timeSinceLastDirectionChange = changeDirectionInterval;
        direction = Random.insideUnitSphere.normalized;
        direction.y = 0f;
    }

    private void Update()
    {
        MoveUFO();

        timeSinceLastDirectionChange += Time.deltaTime;
        if (timeSinceLastDirectionChange >= changeDirectionInterval)
        {
            ChangeDirection();
            timeSinceLastDirectionChange = 0f;
        }
    }

    private void MoveUFO()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void ChangeDirection()
    {
        direction = Random.insideUnitSphere.normalized;
        direction.y = 0f;
    }
}
