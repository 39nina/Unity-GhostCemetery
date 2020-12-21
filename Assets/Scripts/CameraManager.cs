using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject player = default;
    Vector3 offset;

    private void Start()
    {
        // プレイヤーとカメラの距離を計測
        offset = this.transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        this.transform.position = player.transform.position + offset;
        this.transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y + 1.42f, player.transform.position.z));
    }
}
