using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    float fadeSpeed = 0.1f;
    float alfa;　　// 透明度を管理する変数
    public bool isFadeOut = true;
    Image fadeImage;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        alfa = fadeImage.color.a;
    }

    void Update()
    {
        Invoke("StartFadeOut", 6.4f);
    }

    void StartFadeOut()
    {
    if (isFadeOut)
    {
        alfa += fadeSpeed;
        fadeImage.color = new Color(0, 0, 0, alfa);

        // 完全に不透明になったらフェードインを終える
        if (alfa >= 255)
        {
            isFadeOut = false;
        }
    }
    }
}
