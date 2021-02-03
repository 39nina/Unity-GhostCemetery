using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAppearGameManager : MonoBehaviour
{
    // ゾンビ登場シーン用のスクリプト

    [SerializeField] GameObject EntranceBurnOut = default;
    [SerializeField] GameObject EntranceLight = default;

    private void Start()
    {
        Invoke("EntranceLighted", 0.0f);
    }

    void EntranceLighted()
    {
        EntranceLight.SetActive(true);
        EntranceBurnOut.SetActive(false);
    }
}
