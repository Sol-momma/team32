using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using System.Collections.Generic;

public class PlayFabScoreSubmitter : MonoBehaviour
{
    public InputField nameInputField; // ユーザー名入力用のInputField

    public void SubmitScoreWithName()
    {
        if (!GlobalLoginState.IsLoggedIn)
        {
            Debug.LogError("ユーザーはログインしていません。");
            return;
        }
        ResultScreen resultScreen = FindObjectOfType<ResultScreen>(); // ResultScreenを検索
        float score = resultScreen.GetScore(); // ResultScreenからスコアを取得

        // スコアを100倍にして整数に変換し、さらに-1を掛ける
        int scaledScore = Mathf.RoundToInt(score * 100) * -1;

        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
        {
            new StatisticUpdate
            {
                StatisticName = "SpeedScore",
                Value = scaledScore // 負のスケーリングされたスコアを使用
            }
        }
    };

        private void OnStatisticsUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("スコア登録成功");
        SetDisplayName(); // 名前を設定
    }

    private void SetDisplayName()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInputField.text
        };

        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnPlayFabError);
    }

    private void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("表示名を更新しました");
    }

    private void OnPlayFabError(PlayFabError error)
    {
        Debug.Log("PlayFabエラー: " + error.GenerateErrorReport());
    }
}