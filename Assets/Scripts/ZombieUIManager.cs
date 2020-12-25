using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieUIManager : MonoBehaviour
{
    [SerializeField] GameObject ZombieUI = default;
    [SerializeField] GameObject HPSlider = default;

    public void AppearZombieUI()
    {
        ZombieUI.SetActive(true);
    }

    public void DamageByGhost(int hp)
    {
        // ゴーストから攻撃を受けた分だけHPを減らす
        HPSlider.GetComponent<Image>().fillAmount = hp * 0.01f;
    }
}
