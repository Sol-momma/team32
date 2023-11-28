using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        ChangeDirection();
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
        Vector3 newPosition = transform.position + direction * moveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, -10f, 10f);
        newPosition.y = Mathf.Clamp(newPosition.y, -5f, 5f);
        newPosition.z = Mathf.Clamp(newPosition.z, 0f, 10f);

        transform.position = newPosition;
    }

    private void ChangeDirection()
    {
        direction = Random.insideUnitSphere.normalized * moveSpeed;
    }
}
