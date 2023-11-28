using UnityEngine;

public class RandomObjectGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfObjects = 10;
    public float spawnRadius = 10f;
    public float delayBetweenSpawns = 1f; // オブジェクト生成の間隔
    private int generatedObjectsCount = 0;

    void Start()
    {
        InvokeRepeating("GenerateObjectWithDelay", 0f, delayBetweenSpawns);
    }

    void GenerateObjectWithDelay()
    {
        if (generatedObjectsCount < numberOfObjects)
        {
            Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
            randomPosition.y = 0;

            GameObject newCube = Instantiate(cubePrefab, randomPosition, Quaternion.identity);
            generatedObjectsCount++;
        }
        else
        {
            CancelInvoke("GenerateObjectWithDelay");
        }
    }
}
