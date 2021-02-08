using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public float fadeSpeed = 0.1f;
    float alfa;　　// 透明度を管理する変数
    public bool isFadeOut = true;
    public bool isFadeIn = true;
    Image fadeImage;

    void Start()
    {
        fadeImage = this.gameObject.GetComponent<Image>();
        alfa = fadeImage.color.a;
    }


    private void FixedUpdate()
    {
        // メインゲームシーンの場合は、シーン開始時にフェードインからスタート
        if (SceneManager.GetActiveScene().name == "cemetery" && isFadeIn)
        {
            StartFadeIn();
        }
    }

    public void StartFadeOut()
    {
        if (isFadeOut)
        {
            alfa += fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alfa);

            // 完全に不透明になったらフェードアウトを終える
            if (alfa >= 255)
            {
                isFadeOut = false;
            }
        }
    }

    public void StartFadeIn()
    {
        alfa -= fadeSpeed;
        fadeImage.color = new Color(0, 0, 0, alfa);

        // 完全に透明になったらフェードインを終える
        if (alfa <= 0)
        {
            isFadeIn = false;
        }
    }
}
