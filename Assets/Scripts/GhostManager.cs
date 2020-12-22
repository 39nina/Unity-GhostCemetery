﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostManager : MonoBehaviour
{
    [SerializeField] GameObject player = default;
    [SerializeField] GameObject ghost = default;
    [SerializeField] GameObject ghostRigPelvis = default;
    [SerializeField] Collider AttackCollider = default;
    GameObject cane;
    GameObject caneParent;
    float distance;
    bool isApeear = false;
    public static int ghostAttack = 5;
    Vector3 ghostPos;
    Vector3 playerPos;
    Animator animator;
    GameObject effect;
    AudioSource audioSource;
    NavMeshAgent agent;


    private void Awake()
    {
        ghostPos = ghost.transform.position;
        HideAttack();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        ghost.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        cane = GameObject.Find("dm_weapon");
        caneParent = GameObject.Find("Bip001 R Hand");
    }

    private void Update()
    {
        // プレイヤー、ゴーストの位置
        playerPos = player.transform.position;
        ghostPos = this.transform.position;

        // プレイヤーとの距離を計測
        distance = (playerPos - ghostPos).magnitude;

        // ゴーストが出現していない、且つdestroyされていない場合、出現条件を確認
        if(ghost && isApeear == false) 
        {
            Appear();
        }

        // 一定距離以下かつプレイヤーが生きていれば攻撃
        if(distance <= 1.35f && cane.transform.parent == caneParent.transform)
        {
            animator.SetTrigger("Attack");
        }
    }

    private void FixedUpdate()
    {
        // ゴーストが存在していてフィールドに出現している場合、プレイヤーを向いて追いかける
        if (ghost && ghost.activeSelf == true)
        {
            agent.destination = playerPos;
            transform.LookAt(playerPos);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーの攻撃が当たった時は死亡する
        if(ghost && other.gameObject.tag == "AttackEffect")
        {
            animator.SetTrigger("Death");
            audioSource.Play();
        }
    }

    // プレイヤーとの距離が一定以下になったらゴーストをフィールドに出現させる
    void Appear()
    {
        if(distance <= 5.5f)
        {
            ghost.SetActive(true);
            animator.SetTrigger("Appear");
            isApeear = true;
        }
    }

    // ボディの判定を有効にしたり無効にしたりする
    public void ShowAttack()
    {
        AttackCollider.enabled = true;
    }
    public void HideAttack()
    {
        AttackCollider.enabled = false;
    }

    // ダメージを食らったらプレイヤーに向かってくるのを止める
    public void StopPosition()
    {
        agent.isStopped = true;
    }

    // ダメージを食らったら、dieアニメーション終に自身をdestroyする
    public void GhostDie(GameObject deathEffect)
    {
        effect = Instantiate(deathEffect, this.transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);
        // エフェクト、サウンドの実行完了のためrigだけ残して他を先に消滅させる
        Destroy(ghost);
        Destroy(ghostRigPelvis);
        // 数秒後に付属アイテム含めすべてdestroy
        Invoke("DestroyGhostAll", 4.0f);
    }

    void DestroyGhostAll()
    {
        Destroy(this.gameObject);
        Destroy(effect);
    }
}
