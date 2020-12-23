using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel = default;

    public void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
    }
}
