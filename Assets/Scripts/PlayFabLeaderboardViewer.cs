using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using System;

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
                // スコアを-1倍して元に戻し、100で割る
                float correctedScore = (float)item.StatValue * -1 / 100;

                // スコアを時、分、秒に分割
                int hours = (int)correctedScore / 60;
                int minutes = (int)correctedScore % 60;
                float seconds = correctedScore % 1f;

                // ミリ秒を計算（秒の小数部分を100倍し、整数に変換）
                int milliseconds = Mathf.RoundToInt(seconds * 100);

                string hoursText = hours > 0 ? $"{hours}分" : "";
                nameRecordText.text += $"{item.Position + 1}位: {displayName} スコア {hoursText}{minutes:D2}秒{milliseconds:D2}\n";
            }
        }, error =>
        {
            Debug.LogError(error.GenerateErrorReport());
        });
    }
}