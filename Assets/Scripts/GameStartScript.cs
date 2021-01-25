using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartScript : MonoBehaviour
{

    // コントローラでスタートする用の関数
    private void Update()
    {
        if (Input.GetButtonDown("Light"))
        {
            SceneManager.LoadScene("cemetery");
        }
    }

    // 画面上をクリックした際にゲームスタートする用の関数
    public void GameStartButton()
    {
        SceneManager.LoadScene("cemetery");
    }
}
