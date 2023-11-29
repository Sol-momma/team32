using UnityEngine;

public class RandomObjectGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfObjects = 10;
    public float spawnRadius = 10f;
    public float delayBetweenSpawns = 1f;
    public float moveSpeed = 5f; // オブジェクトの移動速度

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

            // Rigidbodyがアタッチされている前提
            Rigidbody cubeRigidbody = newCube.GetComponent<Rigidbody>();
            if (cubeRigidbody != null)
            {
                // 重力の影響を無効にする
                cubeRigidbody.useGravity = false;

                // Z方向に速度を設定
                cubeRigidbody.velocity = Vector3.forward * moveSpeed;
            }
            generatedObjectsCount++;
        }
        else
        {
            CancelInvoke("GenerateObjectWithDelay");
        }
    }
}
