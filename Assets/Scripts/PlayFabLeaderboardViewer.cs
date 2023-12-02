using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;

public class PlayFabLeaderboardViewer : MonoBehaviour
{
    public Text nameRecordText; // 既存のフィールド

    void Start()
    {
        // シーンがロードされたときにランキングを取得する
        GetLeaderboard();
    }

    public void GetLeaderboard()
    {
        if (!GlobalLoginState.IsLoggedIn)
        {
            Debug.LogError("ユーザーはログインしていません。");
            return;
        }

        Debug.Log("ユーザーはログインしています。リーダーボードを取得します。");

        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
        {
            StatisticName = "SpeedScore"
        }, result =>
        {
            nameRecordText.text = ""; // テキストを初期化
            foreach (var item in result.Leaderboard)
            {
                string displayName = item.DisplayName ?? "NoName";
                // スコアを時、分、秒に分割
                int hours = item.StatValue / 3600;
                int minutes = (item.StatValue % 3600) / 60;
                int seconds = item.StatValue % 60;
                // 時、分、秒を結合して表示
                nameRecordText.text += $"{item.Position + 1}位: {displayName} スコア {hours:D2}:{minutes:D2}:{seconds:D2}\n";
            }
        }, error =>
        {
            Debug.LogError(error.GenerateErrorReport());
        });
    }
}
