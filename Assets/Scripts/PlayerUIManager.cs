using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] GameObject HPSlider = default;

    // ゴーストから攻撃を受けた分だけHPを減らす
    public void DamageByGhost(int hp)
    {
        HPSlider.GetComponent<Image>().fillAmount = hp * 0.01f;
    }

    // ゾンビから攻撃を受けた分だけHPを減らす
    public void DamagedByZombie(int hp)
    {
        HPSlider.GetComponent<Image>().fillAmount = hp * 0.01f;
    }
}
