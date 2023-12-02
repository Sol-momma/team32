using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI; // UIを使用するために必要

public class LeaderboardManager : MonoBehaviour
{
    public GameObject textPrefab; // テキストプレハブへの参照
    public Transform contentPanel; // スクロールビューのコンテンツ領域への参照

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "SpeedScore",
            StartPosition = 0,
            MaxResultsCount = 10 // トップ10のスコアを取得
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    private void OnLeaderboardGet(GetLeaderboardResult result)
    {
        // 既存のリーダーボードエントリをクリアする
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        // ランキングデータの取得と表示
        int rank = 1; // ランクの初期値を設定
        foreach (var item in result.Leaderboard)
        {
            // デバッグログ
            Debug.Log($"Rank: {rank}, Name: {item.DisplayName}, Value: {item.StatValue}");

            GameObject newText = Instantiate(textPrefab, contentPanel);
            newText.GetComponent<Text>().text = $"Rank: {rank++}, Name: {item.DisplayName}, Value: {item.StatValue}";
        }
    }

    private void OnError(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }
}
