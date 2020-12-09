using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    [SerializeField] GameObject player = default;
    [SerializeField] GameObject ghost = default;
    float distance;
    Vector3 ghostPos;

    private void Awake()
    {
        ghostPos = ghost.transform.position;
    }

    private void Start()
    {
        ghost.SetActive(false);
    }

    private void Update()
    {
        // プレイヤーとの距離を計測
        distance = (player.transform.position - ghostPos).magnitude;
        Appear();
    }

    // 距離が一定以下になったら出現
    void Appear()
    {
        if(distance <= 7)
        {
            ghost.SetActive(true);
        }
    }
}
