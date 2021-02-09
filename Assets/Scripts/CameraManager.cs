using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    GameObject player;
    GameObject mainCamera;
    Vector3 offset;
    Vector3 angle;
    float rotateSpeed = 1.3f;

    private void Start()
    {
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");

        // プレイヤーとカメラの距離を計測
        offset = this.transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        if (player)
        {
            this.transform.position = player.transform.position + offset;
            this.transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y + 1.42f, player.transform.position.z));

            RotateCamera();
        }
    }

    void RotateCamera()
    {
        // 右スティックの水平方向の入力に伴って、プレイヤーを中心にカメラが回転するようにする
        angle += new Vector3(Input.GetAxisRaw("RstickHorizontal") * rotateSpeed, 0, 0);
        this.transform.RotateAround(player.transform.position, Vector3.up, angle.x);
    }
}
