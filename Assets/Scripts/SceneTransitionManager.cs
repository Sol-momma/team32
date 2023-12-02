using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    // 遅延時間（秒）
    public float delay = 2.0f;

    // シーン遷移を行うメソッド
    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(LoadSceneAfterDelay(sceneName));
    }

    // 遅延後にシーンをロードするコルーチン
    private IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
