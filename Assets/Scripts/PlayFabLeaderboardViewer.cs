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
                // スコアを-1倍して元に戻す
                int correctedScore = item.StatValue * -1;

                // スコアを時、分、秒に分割
                int hours = correctedScore / 3600;
                int minutes = (correctedScore % 3600) / 60;
                int seconds = correctedScore % 60;

                string hoursText = hours > 0 ? $"{hours}分" : "";
                nameRecordText.text += $"{item.Position + 1}位: {displayName} スコア {hoursText}{minutes:D2}秒{seconds:D2}\n";
            }
        }, error =>
        {
            Debug.LogError(error.GenerateErrorReport());
        });
    }
}