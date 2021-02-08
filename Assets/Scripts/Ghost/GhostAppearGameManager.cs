using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostAppearGameManager : MonoBehaviour
{
    [SerializeField] GameObject GameStartPanel = default;
    [SerializeField] FadeController fadeController = default;
    bool fadeOut = false;

    void Update()
    {
        // 丸が押されたら、ゲームスタートの説明画面を次に送る
        if (GameStartPanel.activeSelf == true && Input.GetButtonDown("Light"))
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            fadeOut = true;
            Invoke("LoadToMainScene", 0.4f);
        }

        // フェードアウトフラグがtrueになったらフェードアウト開始
        if(fadeOut)
        {
            StartFadeOut();
        }
    }

    // フェードアウト開始用のフラグをセットするメソッド
    void StartFadeOut()
    {
        fadeController.StartFadeOut();
    }

    // メインのゲームシーンへ遷移するメソッド
    void LoadToMainScene()
    {
        SceneManager.LoadScene("cemetery");
    }
}
