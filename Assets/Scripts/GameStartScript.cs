using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartScript : MonoBehaviour
{
    [SerializeField] GameObject doorSE = default;
    [SerializeField] FadeController fadeController = default;
    bool fadeOutStart = false;

    private void Update()
    {
        // スタートボタンが押されたら音＋フェードアウトが始まり、暗転したタイミングでシーン切り替え
        if (Input.GetButtonDown("Light"))
        {
            doorSE.GetComponent<AudioSource>().Play();
            fadeOutStart = true;
            Invoke("GameStart", 1.5f);
        }

        // フェードアウト開始フラグがtrueになったら、updateでフェードアウト関数を呼び出す
        if(fadeOutStart == true)
        {
            fadeController.StartFadeOut();
        }

    }

    void GameStart()
    {
        SceneManager.LoadScene("GhostAppearScene");
    }
}
