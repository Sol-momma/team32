using UnityEngine;

public class RandomObjectGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfObjects = 10;
    public float spawnRadius = 10f;
    public float delayBetweenSpawns = 1f;

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

            // ClickToDeleteスクリプトをアタッチ
            ClickToDelete clickToDeleteScript = newCube.AddComponent<ClickToDelete>();

            // 生成されたキューブに対してClickToDeleteスクリプトがアタッチされる
            clickToDeleteScript.enabled = true;

            generatedObjectsCount++;
        }
        else
        {
            CancelInvoke("GenerateObjectWithDelay");
        }
    }
}
