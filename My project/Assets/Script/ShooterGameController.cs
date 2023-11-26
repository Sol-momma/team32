// クリックしたオブジェクトを消す処理（撃つ部分の処理）
using UnityEngine;

public class ShooterGameController : MonoBehaviour
{
    public Camera playerCamera;
    public Texture2D crosshairTexture; // 照準のテクスチャ
    private Vector2 crosshairHotspot; // 照準の中心点
    public int score = 0;

    void Start()
    {
        // 照準の中心を計算
        crosshairHotspot = new Vector2(crosshairTexture.width / 2, crosshairTexture.height / 2);

        // カーソルをカスタムの照準に変更
        Cursor.SetCursor(crosshairTexture, crosshairHotspot, CursorMode.Auto);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // マウス左クリックを検出
        {
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // ここでhit.transform.gameObjectがクリックされたオブジェクト
                Destroy(hit.transform.gameObject); // オブジェクトを破壊
                score++; // 得点を加算
            }
        }
    }
}
