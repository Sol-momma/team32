using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using System.Collections.Generic;
public class PlayFabScoreSubmitter : MonoBehaviour
{

    public InputField nameInputField; 
    public Text errorMessageText;     
    public SceneChanger sceneChanger; 



    void Start()
    {
       
        errorMessageText.text = "";
        errorMessageText.gameObject.SetActive(false); 
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
            errorMessageText.gameObject.SetActive(true); 
            return;
        }


        ResultScreen resultScreen = FindObjectOfType<ResultScreen>(); // ResultScreenを検索
        float score = resultScreen.GetScore(); // ResultScreenからスコアを取得
        Debug.Log(score);

        // スコアを100倍にして整数に変換し、さらに-1を掛ける
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
            Debug.Log("スコア登録成功"));
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
            Debug.Log(("表示名を更新しました");
            sceneChanger.ChangeSceneToRanking(); 
        }, OnPlayFabError);

    }

    private void OnPlayFabError(PlayFabError error)
    {
        Debug.LogError("PlayFabエラー: " + error.GenerateErrorReport());
    }
}
