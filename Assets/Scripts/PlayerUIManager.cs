using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] GameObject HPSlider = default;

    public void DamageByGhost(int hp)
    {
        // ゴーストから攻撃を受けた分だけHPを減らす
        HPSlider.GetComponent<Image>().fillAmount = hp * 0.01f;
    }
}
