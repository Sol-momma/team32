using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // 生成するオブジェクトの配列
    public float spawnInterval = 5f; // オブジェクトを生成する間隔
    public float spawnRadius = 10f; // オブジェクトが出現する範囲の半径

    private void Start()
    {
        InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
    }

    void SpawnObject()
    {
        // ランダムな位置を計算
        Vector3 randomPosition = new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius));

        // ランダムなオブジェクトを選択
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

        // オブジェクトを生成
        GameObject newObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }
}
