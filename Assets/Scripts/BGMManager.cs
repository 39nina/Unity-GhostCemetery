using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public bool DontDestroyEnabled = true;

    private void Start()
    {
        if (DontDestroyEnabled)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
