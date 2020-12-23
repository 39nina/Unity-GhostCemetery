using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleManager : MonoBehaviour
{
    [SerializeField] GameObject candle_off = default;
    [SerializeField] GameObject candle_on1 = default;
    [SerializeField] GameObject candle_on2 = default;
    [SerializeField] GameObject candle_on3 = default;
    [SerializeField] GameObject Player = default;
    GameManager gameManager = default;
    PlayerManager playerManager = default;
    Vector3 candlePos;
    Vector3 playerPos;
    float distance;

    private void Start()
    {
        candlePos = this.gameObject.transform.position;
        playerManager = Player.GetComponent<PlayerManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (playerManager)
        {
            // プレイヤーとの距離を計測
            playerPos = Player.transform.position;
            // キャンドルの高さがバラバラなので、y座標のみプレイヤーと同じとして設定し直す
            candlePos = new Vector3(candlePos.x, playerPos.y, candlePos.z);
            distance = (candlePos - playerPos).magnitude;

            LightCandle();
        }
    }

    // 一定以下の距離で○ボタンを押すと点灯
    void LightCandle()
    {
        if (distance <= 1.2f && Input.GetButtonDown("Light"))
        {
            // プレイヤーの点灯アニメーション
            playerManager.LightCandle();
            // アニメーション開始から一拍置いてキャンドル点灯
            Invoke("LightOnOff", 1.0f);

            // 点灯数を数えるリストを増加
            gameManager.LightAdd();
        }
    }

    // 点灯のメソッド（暗い時のオブジェクトはfalseに変更）
    void LightOnOff()
    {
        candle_off.SetActive(false);
        candle_on1.SetActive(true);
        candle_on2.SetActive(true);
        candle_on3.SetActive(true);
    }
}
