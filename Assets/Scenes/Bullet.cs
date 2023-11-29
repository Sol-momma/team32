using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 3.0f; // 弾丸が消えるまでの時間（秒）

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
