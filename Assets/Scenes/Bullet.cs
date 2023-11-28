using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffectPrefab;

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトにキューブが含まれているか確認
        if (collision.gameObject.CompareTag("CubeTag"))
        {
            // キューブを破棄
            Destroy(collision.gameObject);
        }

        // 弾を破棄
        Destroy(gameObject);
    }


}
