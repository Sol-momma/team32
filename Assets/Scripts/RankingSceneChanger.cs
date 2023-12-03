using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneToRanking()
    {
        StartCoroutine(ChangeSceneAfterDelay("RankingScene", 2f)); // 2秒後にシーン遷移するコルーチンを開始
    }

    IEnumerator ChangeSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay); // 2秒間待機
        SceneManager.LoadScene(sceneName); // シーンをロード
    }
}
