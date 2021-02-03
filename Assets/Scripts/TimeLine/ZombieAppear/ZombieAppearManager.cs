using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAppearManager : MonoBehaviour
{
    public AudioClip AttackSE;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void PlayAttackSE()
    {
        audioSource.PlayOneShot(AttackSE);
    }
}
