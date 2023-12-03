using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using System.Collections.Generic;
public class PlayFabLogin : MonoBehaviour
{
    public Text nameRecordText; // 既存のフィールド
    public InputField nameInputField; // ユーザー名入力用のInputField

    private void OnEnable()
    {
        PlayFabAuthService.OnLoginSuccess += PlayFabAuthService_OnLoginSuccess;
        PlayFabAuthService.OnPlayFabError += PlayFabAuthService_OnPlayFabError;
    }

    private void OnDisable()
    {
        PlayFabAuthService.OnLoginSuccess -= PlayFabAuthService_OnLoginSuccess;
        PlayFabAuthService.OnPlayFabError -= PlayFabAuthService_OnPlayFabError;
    }

    private void PlayFabAuthService_OnLoginSuccess(LoginResult success)
    {
        Debug.Log("ログイン成功");
        GetLeaderboard();
    }

    private void PlayFabAuthService_OnPlayFabError(PlayFabError error)
    {
        Debug.Log("ログイン失敗: " + error.GenerateErrorReport());
    }

    void Start()
    {
        // ここでログイン処理を実行する
        PlayFabAuthService.Instance.Authenticate(Authtypes.Silent);
    }


    public void GetLeaderboard()
    {
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
        {
            StatisticName = "SpeedScore"
        }, result =>
        {
            nameRecordText.text = ""; // テキストを初期化
            foreach (var item in result.Leaderboard)
            {
                string displayName = item.DisplayName ?? "NoName";
                nameRecordText.text += $"{item.Position + 1}位: {displayName} スコア {item.StatValue}\n";
            }
        }, error =>
        {
            Debug.Log(error.GenerateErrorReport());
        });
    }
    public void SubmitScoreWithName()
    {
        ResultScreen resultScreen = FindObjectOfType<ResultScreen>(); // ResultScreenを検索
        float score = resultScreen.GetScore(); // ResultScreenからスコアを取得

        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "SpeedScore",
                    Value = (int)score // スコアを整数に変換して使用
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnStatisticsUpdate, OnPlayFabError);
    }

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
        GetLeaderboard(); // リーダーボードを更新
    }
    private void OnPlayFabError(PlayFabError error) // このメソッドを追加
    {
        Debug.Log("PlayFabエラー: " + error.GenerateErrorReport());
    }
}