// クリックしたオブジェクトを消す処理（撃つ部分の処理）
using UnityEngine;
using TMPro; // TextMeshProを使用するために必要

public class ShooterGameController : MonoBehaviour
{
    public Camera playerCamera;
    public Texture2D crosshairTexture;
    private Vector2 crosshairHotspot;
    public int score = 0;
    public TextMeshProUGUI scoreText; // この行を変更

    void Start()
    {
        // カーソルの設定など
        UpdateScoreUI(); // 初期スコアをUIに表示

        // カーソルをカスタムの照準に変更
        Cursor.SetCursor(crosshairTexture, crosshairHotspot, CursorMode.Auto);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    score += target.scoreValue;
                }
                else
                {
                    score++; // ターゲットコンポーネントがない場合は1点を加算
                }
                UpdateScoreUI(); // スコアUIを更新
                Destroy(hit.transform.gameObject);
            }
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString(); // スコアをテキストで表示
    }
}
