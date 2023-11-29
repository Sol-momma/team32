using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    void Update()
    {
        // マウスの左クリックを検知
        if (Input.GetMouseButtonDown(0))
        {
            // クリックされた時の処理をここに追加
            Debug.Log("Mouse Clicked!");
        }
    }


    void ShootBullet()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;

            // 弾の生成
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            // カメラからクリックした位置に向かうベクトル
            Vector3 direction = (targetPosition - transform.position).normalized;
            // 弾を飛ばす
            bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
        }
    }
}
