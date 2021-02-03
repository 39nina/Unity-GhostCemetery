using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieAppearGameManager : MonoBehaviour
{
    // ゾンビ登場シーン用のスクリプト

    [SerializeField] GameObject EntranceBurnOut = default;
    [SerializeField] GameObject EntranceLight = default;

    private void Start()
    {
        Invoke("EntranceLighted", 0.0f);
        Invoke("ChangeZombieBattleScene", 7.5f);
    }

    void EntranceLighted()
    {
        EntranceLight.SetActive(true);
        EntranceBurnOut.SetActive(false);
    }

    void ChangeZombieBattleScene()
    {
        SceneManager.LoadScene("ZombieBattleScene");
    }
}
