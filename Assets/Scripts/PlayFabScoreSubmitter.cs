using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using System.Collections.Generic;

public class PlayFabScoreSubmitter : MonoBehaviour
{
    public InputField nameInputField; // ���[�U�[�����͗p��InputField

    public void SubmitScoreWithName()
    {
        if (!GlobalLoginState.IsLoggedIn)
        {
            Debug.LogError("���[�U�[�̓��O�C�����Ă��܂���B");
            return;
        }

        ResultScreen resultScreen = FindObjectOfType<ResultScreen>(); // ResultScreen������
        float score = resultScreen.GetScore(); // ResultScreen����X�R�A���擾
        Debug.Log(score);

        // �X�R�A��100�{�ɂ��Đ����ɕϊ����A�����-1���|����
        int scaledScore = Mathf.RoundToInt(score * 100) * -1;

        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
        {
            new StatisticUpdate
            {
                StatisticName = "SpeedScore",
                Value = scaledScore // ���̃X�P�[�����O���ꂽ�X�R�A���g�p
            }
        }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnStatisticsUpdate, OnPlayFabError);
    }

    private void OnStatisticsUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("�X�R�A�o�^����");
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
    }

    private void OnPlayFabError(PlayFabError error)
    {
        Debug.Log("PlayFab�G���[: " + error.GenerateErrorReport());
    }
}