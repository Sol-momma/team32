using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChengeScene : MonoBehaviour
{
    public void ChangeButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
