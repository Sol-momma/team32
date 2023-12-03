using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;

public class PlayFabLoginManager : MonoBehaviour
{
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
        GlobalLoginState.SetLoginState(true, success.PlayFabId);
    }

    private void PlayFabAuthService_OnPlayFabError(PlayFabError error)
    {
        Debug.Log("ログイン失敗:" + error.GenerateErrorReport());
    }

    void Start()
    {
        PlayFabAuthService.Instance.Authenticate(Authtypes.Silent);
    }
}