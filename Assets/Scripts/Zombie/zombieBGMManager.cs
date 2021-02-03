using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zombieBGMManager : MonoBehaviour
{
    public bool DontDestroyEnabled = true;

    private void Start()
    {
        if (DontDestroyEnabled)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // ゲームクリア後、リスタートした時にはこのBGMが停止されるようにする
    public void ZombieBGMStop()
    {
        SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
    }
}
