using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using System.Collections.Generic;
public class PlayFabScoreSubmitter : MonoBehaviour
{
    public InputField nameInputField; // ユーザー名入力用のInputField
    public Text errorMessageText;     // エラーメッセージ表示用のText
    public SceneChanger sceneChanger; // SceneChangerへの参照


    void Start()
    {
        // 初期化時にエラーメッセージを非表示に設定
        errorMessageText.text = "";
        errorMessageText.gameObject.SetActive(false); // 必要に応じて
    }
    public void SubmitScoreWithName()
    {
        if (!GlobalLoginState.IsLoggedIn)
        {
            Debug.LogError("ユーザーはログインしていません。");
            return;
        }

        if (nameInputField.text.Length > 6)
        {
            errorMessageText.text = "ユーザー名は6文字までなのだ";
            errorMessageText.gameObject.SetActive(true); // エラーメッセージを表示
            return;
        }

        // エラーがない場合はエラーメッセージを非表示に
        errorMessageText.gameObject.SetActive(false);

        ResultScreen resultScreen = FindObjectOfType<ResultScreen>();
        float score = resultScreen.GetScore();
        Debug.Log(score);

        int scaledScore = Mathf.RoundToInt(score * 100) * -1;

        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "SpeedScore",
                    Value = scaledScore
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, result =>
        {
            Debug.Log("スコア登録成功");
            SetDisplayName();
        }, OnPlayFabError);
    }

    private void SetDisplayName()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInputField.text
        };

        PlayFabClientAPI.UpdateUserTitleDisplayName(request, result =>
        {
            Debug.Log("表示名を更新しました");
            sceneChanger.ChangeSceneToRanking(); // ここでシーン遷移をトリガー
        }, OnPlayFabError);
    }

    private void OnPlayFabError(PlayFabError error)
    {
        Debug.LogError("PlayFabエラー: " + error.GenerateErrorReport());
    }
}
