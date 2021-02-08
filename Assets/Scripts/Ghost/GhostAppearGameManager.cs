using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostAppearGameManager : MonoBehaviour
{
    [SerializeField] GameObject GameStartPanel = default;
    [SerializeField] FadeController fadeController = default;
    [SerializeField] AudioSource audioSource1 = default;
    [SerializeField] AudioSource audioSource2 = default;
    [SerializeField] AudioClip AttackSE = default;
    bool fadeOut = false;
    bool BGMFadeOut = false;
    float BGMFadeSpeed = 0.99f;

    private void Start()
    {
        // ゴーストがプレイヤーにぶつかる場面でSEを鳴らす
        Invoke("GhostAttackSE", 3.65f);

        // ゴースト登場から一定時間後になったらBGMがフェードアウトする
        Invoke("StartBGMFadeOut", 25.5f);
    }

    void Update()
    {
        // 丸が押されたらゲームスタートの説明画面を次に送る
        if (GameStartPanel.activeSelf == true && Input.GetButtonDown("Light"))
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            fadeOut = true;
            // ボタン押下後、フェードアウトの一瞬を挟んで次のシーンへ遷移
            Invoke("LoadToMainScene", 0.4f);
        }

        // フェードアウトフラグがtrueになったらフェードアウト開始
        if(fadeOut)
        {
            StartFadeOut();
        }

        // BGMフェードアウトフラグがtrueになったらBGMフェードアウト開始
        if (BGMFadeOut)
        {
            audioSource1.volume *= BGMFadeSpeed;
            audioSource2.volume *= BGMFadeSpeed;
        }
    }

    // 画面フェードアウト開始用のフラグをセットするメソッド
    void StartFadeOut()
    {
        fadeController.StartFadeOut();
    }

    //BGMフェードアウト開始用のフラグをセットするメソッド
    void StartBGMFadeOut()
    {
        BGMFadeOut = true;
    }

    // メインのゲームシーンへ遷移するメソッド
    void LoadToMainScene()
    {
        SceneManager.LoadScene("cemetery");
    }

    // ゴースト衝突時のSE再生
    void GhostAttackSE()
    {
        this.GetComponent<AudioSource>().PlayOneShot(AttackSE);
    }
}
