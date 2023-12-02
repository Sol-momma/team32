using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject RankingView; // スクロールビューへの参照

    public void ToggleRankingDisplay()
    {
        // スクロールビューの表示状態を切り替える
        RankingView.SetActive(!RankingView.activeSelf);
    }
}
