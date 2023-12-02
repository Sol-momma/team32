using UnityEngine;
using UnityEngine.UI; 
using PlayFab.ClientModels;
using PlayFab;
public class PlayFabLogin : MonoBehaviour
{
    public Text nameRecordText; // 追加: ランキングデータを表示するTextへの参照

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
}