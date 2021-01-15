using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel = default;
    public List<bool> Lights = new List<bool>();
    int number;  // リストLightの何番目まで入ってるか（いくつ点灯済か）
    [SerializeField] DungeonEntranceManager dungeonEntranceManager = default;
    [SerializeField] ZombieManager ZombieManager = default;
    [SerializeField] ZombieUIManager zombieUIManager = default;
    [SerializeField] GameObject player = default;
    [SerializeField] GameObject RetryButton = default;

    private void Update()
    {
        if (number == 13)
        {
            // 奥のエントランスをアクティブにし、ゾンビを出現させる
            Invoke("EntranceOn", 2.5f);
            Invoke("AppearZombie", 2.5f);
        }

        // プレイヤーが消失したら、数秒後にゲームオーバーメソッドを表示
        if (!player)
        {
            Invoke("ShowGameOver", 2.0f);
        }

        // ゲームオーバー画面で○かボタンを押したらリスタート
        RetryWithController();
    }

    void AppearZombie()
    {
        ZombieManager.AppearZombie();
        zombieUIManager.AppearZombieUI();
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

    // ゲームオーバー画面を表示するメソッド
    public void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
    }

    // ゲームオーバー画面でリトライボタンを押すと再スタート
    public void Retry()
    {
        Invoke("LoadNewGame", 1.0f);
    }
    void LoadNewGame()
    {
        SceneManager.LoadScene("cemetery");
    }

    // コントローラーでリトライするためのメソッド（Retryメソッドはボタン押下時兼用）
    void RetryWithController()
    {
        if (RetryButton.activeSelf && Input.GetButtonDown("Light"))
        {
            SceneManager.LoadScene("cemetery");
        }
    }
}
