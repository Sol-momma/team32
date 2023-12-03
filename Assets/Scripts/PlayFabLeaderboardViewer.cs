using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;

public class PlayFabLeaderboardViewer : MonoBehaviour
{
    public Text rankingText; // ランキング表示用のテキスト
    public Text scoreText;   // スコア表示用のテキスト

    void Start()
    {
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
            rankingText.text = "";
            scoreText.text = "";

            foreach (var item in result.Leaderboard)
            {
                string displayName = item.DisplayName ?? "NoName";

                string line = $"{item.Position + 1}位:{displayName}";
                line = line.PadRight(20); // 20は適宜調整

                float correctedScore = (float)item.StatValue * -1 / 100;
                int hours = (int)correctedScore / 3600;
                int minutes = ((int)correctedScore % 3600) / 60;
                int seconds = (int)correctedScore % 60;
                int milliseconds = Mathf.RoundToInt((correctedScore - (int)correctedScore) * 100);

                string hoursText = hours > 0 ? $"{hours}時間" : "";
                string scoreLine = $"{hoursText}{minutes:D2}分{seconds:D2}秒{milliseconds:D2}";

                rankingText.text += $"{line}\n";
                scoreText.text += $"スコア：{scoreLine}\n";
            }
        }, error =>
        {
            Debug.LogError(error.GenerateErrorReport());
        });
    }
}
