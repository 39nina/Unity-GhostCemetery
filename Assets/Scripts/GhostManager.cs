using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    [SerializeField] GameObject player = default;
    float distance;
    Vector3 ghostPos;

    private void Awake()
    {
        ghostPos = this.transform.position;
        //Debug.Log(ghostPos);
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        Debug.Log(player.transform.position);
        // プレイヤーとの距離を計測
        distance = (player.transform.position - ghostPos).magnitude;
        Debug.Log(distance);
        Appear();
    }

    // 距離が一定以下になったら出現
    void Appear()
    {
        if(distance <= 100)
        {
            this.gameObject.SetActive(true);
        }
    }
}
