using UnityEngine;

public class ClickToDelete : MonoBehaviour
{
    void Update()
    {
        // マウスの左クリックを検知
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Rayがオブジェクトに当たったかどうかを判定
            if (Physics.Raycast(ray, out hit))
            {
                // 当たったオブジェクトが自分自身であるかを確認
                if (hit.collider.gameObject == gameObject)
                {
                    // クリックされたオブジェクトを削除
                    Destroy(gameObject);
                }
            }
        }
    }
}
