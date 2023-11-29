using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorTexture; // 照準のテクスチャ
    public Vector2 hotSpot = new Vector2(16, 16); // テクスチャのホットスポット

    void Start()
    {
        // 照準のテクスチャを設定
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
}
