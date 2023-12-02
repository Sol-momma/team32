using UnityEngine;

public class RankingUIController : MonoBehaviour
{
    public GameObject RankingView; // スクロールビューへの参照

    public void ToggleRankingDisplay()
    {
        RankingView.SetActive(!RankingView.activeSelf);
    }
}

