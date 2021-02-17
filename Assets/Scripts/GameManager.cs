using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel = default;
    [SerializeField] GameObject GameClearPanel = default;
    public List<bool> Lights = new List<bool>();
    int number;  // リストLightの何番目まで入ってるか（いくつ点灯済か）
    [SerializeField] DungeonEntranceManager dungeonEntranceManager = default;
    GameObject player = default;
    [SerializeField] GameObject RetryButton1 = default;
    [SerializeField] GameObject RetryButton2 = default;
    [SerializeField] Text CandleNumberUI = default;
    [SerializeField] GameObject clearIcon = default;
    [SerializeField] AudioSource audioSource = default;
    int currentNumber = 0;
    bool isBGMFadeOut = false;
    GameObject zombieDeathEffect;
    zombieBGMManager zombieBGMManager;
    [SerializeField] FadeController fadeController;
    [SerializeField] PlayerManager playerManager = default;
    GameObject mainCamera;
    GameObject PlayerUI;

    private void Start()
    {
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
        PlayerUI = GameObject.Find("PlayerUICanvas");

        // ZombieBattleSceneでは、ゾンビBGMを取得
        if (CandleNumberUI.text == "13")
        {
            zombieBGMManager = GameObject.Find("BGM").GetComponent<zombieBGMManager>();
        }

        // ゴーストのシーンではプレイヤーとカメラを破壊しないよう設定、ゾンビのシーンではリトライに向けて設定を解除
        if(SceneManager.GetActiveScene().name == "cemetery")
        {
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(mainCamera);
            DontDestroyOnLoad(PlayerUI);
        }
        if(SceneManager.GetActiveScene().name == "ZombieBattleScene")
        {
            SceneManager.MoveGameObjectToScene(player, SceneManager.GetActiveScene());
            SceneManager.MoveGameObjectToScene(mainCamera, SceneManager.GetActiveScene());
            SceneManager.MoveGameObjectToScene(PlayerUI, SceneManager.GetActiveScene());
        }
    }

    private void Update()
    {
        // 点灯済キャンドルのカウント(number)が１つ上がってから１秒後に、表示もカウントアップ
        if (currentNumber != number)
        {
            currentNumber = number;
            Invoke("changeNumber", 1.1f);
        }

        // すべてのキャンドルに点灯が完了したら、クリアマークを表示し、フェードアウトしてゾンビシーンに遷移
        if (number == 13)
        {
            Invoke("ActiveClearIcon", 1.1f);
            // フェードアウトしたあとにゾンビ登場ムービーに遷移
            Invoke("FadeOutToZombieScene", 2.8f);
            Invoke("LoatToAppearZombie", 3.3f);
        }

        // ゾンビ登場シーンに遷移する際にBGMフェードアウト
        if (isBGMFadeOut)
        {
            audioSource.volume *= 0.97f;
        }

        // プレイヤーが消失したら、数秒後にゲームオーバーメソッドを表示
        if (!player && GameClearPanel.activeSelf == false)
        {
            Invoke("ShowGameOver", 2.0f);
        }

        // ゾンビが倒れたら、数秒後にゲームオーバーメソッドを表示
        // ゾンビが死んだ時のエフェクトを取得
        zombieDeathEffect = GameObject.Find("SoulSuperEvilDeath(Clone)");
        if (zombieDeathEffect && GameOverPanel.activeSelf == false)
        {
            Invoke("ShowGameClear", 2.0f);
        }

        // ゲームオーバー画面で○かボタンを押したらリスタート
        RetryWithController();
    }

    // 画面上の数字表記を変更
    void changeNumber()
    {
        // 1桁の場合は数字の左にスペースを入れて表示
        if (number < 10)
        {
            CandleNumberUI.text = " " + number.ToString();
        }
        else
        {
            CandleNumberUI.text = number.ToString();
        }
    }

    public void LightAdd()
    {
        Lights.Add(true);
        number = Lights.Count;
    }

    // ゲームオーバー画面を表示するメソッド
    public void ShowGameOver()
    {
        if (zombieBGMManager)
        {
            zombieBGMManager.ZombieBGMStop();
        }
        GameOverPanel.SetActive(true);
    }

    // ゲームクリア画面を表示するメソッド
    public void ShowGameClear()
    {
        zombieBGMManager.ZombieBGMStop();
        GameClearPanel.SetActive(true);
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
        if ((RetryButton1.activeInHierarchy || RetryButton2.activeInHierarchy) && Input.GetButtonDown("Light"))
        {
            SceneManager.LoadScene("cemetery");
        }
    }

    // 全キャンドル点灯後の各アクション
    void ActiveClearIcon()
    {
        clearIcon.SetActive(true);
        isBGMFadeOut = true;
    }
    void FadeOutToZombieScene()
    {
        // 画面とBGMをフェードアウト
        fadeController.StartFadeOut();
    }
    void LoatToAppearZombie()
    {
        SceneManager.LoadScene("ZombieAppearScene");
    }
}