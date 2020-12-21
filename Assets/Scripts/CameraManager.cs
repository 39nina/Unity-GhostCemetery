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
        offset = this.GetComponent<Transform>().position - player.transform.position;
    }

    private void FixedUpdate()
    {
        this.GetComponent<Transform>().position = player.transform.position + offset;
    }
}
