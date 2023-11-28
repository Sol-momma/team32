using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    public GameObject ufoPrefab;
    public float spawnInterval = 5f;
    public float spawnRadius = 10f;

    void Start()
    {
        InvokeRepeating("SpawnUFO", 0f, spawnInterval);
    }

    void SpawnUFO()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;

        spawnPosition = ClampPosition(spawnPosition);

        Instantiate(ufoPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 ClampPosition(Vector3 spawnPosition)
    {
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, -16f, 16f);
        spawnPosition.y = Mathf.Clamp(spawnPosition.y, -5f, 7f);
        spawnPosition.z = Mathf.Clamp(spawnPosition.z, 0f, 10f);
        return spawnPosition;
    }
}
