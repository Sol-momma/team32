using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using System.Collections.Generic;
public class PlayFabLogin : MonoBehaviour
{
    public Text nameRecordText; // �����̃t�B�[���h
    public InputField nameInputField; // ���[�U�[�����͗p��InputField

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
        Debug.Log("���O�C������");
        GetLeaderboard();
    }

    private void PlayFabAuthService_OnPlayFabError(PlayFabError error)
    {
        Debug.Log("���O�C�����s: " + error.GenerateErrorReport());
    }

    void Start()
    {
        // �����Ń��O�C�����������s����
        PlayFabAuthService.Instance.Authenticate(Authtypes.Silent);
    }


    public void GetLeaderboard()
    {
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
        {
            StatisticName = "SpeedScore"
        }, result =>
        {
            nameRecordText.text = ""; // �e�L�X�g��������
            foreach (var item in result.Leaderboard)
            {
                string displayName = item.DisplayName ?? "NoName";
                nameRecordText.text += $"{item.Position + 1}��: {displayName} �X�R�A {item.StatValue}\n";
            }
        }, error =>
        {
            Debug.Log(error.GenerateErrorReport());
        });
    }
    public void SubmitScoreWithName()
    {
        ResultScreen resultScreen = FindObjectOfType<ResultScreen>(); // ResultScreen������
        float score = resultScreen.GetScore(); // ResultScreen����X�R�A���擾

        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "SpeedScore",
                    Value = (int)score // �X�R�A�𐮐��ɕϊ����Ďg�p
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnStatisticsUpdate, OnPlayFabError);
    }

    private void OnStatisticsUpdate(UpdatePlayerStatisticsResult result)
    {
        // Debug.Log("�X�R�A�o�^����");
        SetDisplayName(); // ���O��ݒ�
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
        // Debug.Log("�\�������X�V���܂���");
        GetLeaderboard(); // ���[�_�[�{�[�h���X�V
    }
    private void OnPlayFabError(PlayFabError error) // ���̃��\�b�h��ǉ�
    {
        Debug.Log("PlayFab�G���[: " + error.GenerateErrorReport());
    }
}