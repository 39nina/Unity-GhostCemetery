using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel = default;
    public List<bool> Lights = new List<bool>();
    int number;  // リストLightの何番目まで入ってるか（いくつ点灯済か）
    [SerializeField] DungeonEntranceManager dungeonEntranceManager = default;

    private void Update()
    {
        if (number == 13)
        {
            Invoke("EntranceOn", 2.5f);
        }
    }

    void EntranceOn()
    {
        dungeonEntranceManager.EntranceOn();
    }

    public void LightAdd()
    {
        Lights.Add(true);
        number = Lights.Count;
    }

    public void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
    }
}
