using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public float fadeSpeed = 0.1f;
    float alfa;　　// 透明度を管理する変数
    public bool isFadeOut = true;
    Image fadeImage;

    void Start()
    {
        fadeImage = this.gameObject.GetComponent<Image>();
        alfa = fadeImage.color.a;
    }

    public void StartFadeOut()
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
