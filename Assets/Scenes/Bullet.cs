using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffectPrefab;

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトにエフェクトを再生してから弾を破棄
        Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
