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
    Vector3 candlePos;
    Vector3 playerPos;
    float distance;

    private void Start()
    {
        candlePos = this.gameObject.transform.position;
    }

    private void Update()
    {
        // プレイヤーとの距離を観測
        playerPos = Player.transform.position;
        distance = (candlePos - playerPos).magnitude;

        LightCandle();
    }

    // 一定以下の距離で○ボタンを押すと点灯
    void LightCandle()
    {
        if (distance <= 1.2f && Input.GetButtonDown("Light"))
        {
            candle_off.SetActive(false);
            candle_on1.SetActive(true);
            candle_on2.SetActive(true);
            candle_on3.SetActive(true);
        }
    }
}
