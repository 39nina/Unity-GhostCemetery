using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEntranceManager : MonoBehaviour
{
    [SerializeField] GameObject candle_off = default;
    [SerializeField] GameObject candle_on1 = default;
    [SerializeField] GameObject candle_on2 = default;
    [SerializeField] GameObject candle_on3 = default;

    public void EntranceOn()
    {
        candle_off.SetActive(false);
        candle_on1.SetActive(true);
        candle_on2.SetActive(true);
        candle_on3.SetActive(true);
    }
}
