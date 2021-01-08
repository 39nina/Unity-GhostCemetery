using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAnimations : MonoBehaviour {

	public GameObject zombie;
    public GameObject player;
    public AnimationClip IdleAnim;
	public AnimationClip RunAnim;
	public AnimationClip AttackAnim;
	public AnimationClip GetHitAnim;
	public AnimationClip DieAnim;

	NavMeshAgent agent;
    Vector3 playerPos;
    [SerializeField] GameObject weapon = default;
    [SerializeField] ZombieUIManager zombieUIManager = default;
    [SerializeField] GameObject zombieBody = default;
    [SerializeField] GameObject zombieWeapon = default;
    [SerializeField] GameObject deathEffect = default;
    int ZombieHP = 100;
    public bool ZombieDead = false;
    bool zombieRun = true;
    bool zombieDeath = false;
    AudioSource audioSource;
    public AudioClip damagedSE;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }
	
	void Update() {

        // プレイヤーの現在地を取得
        playerPos = player.transform.position;

        // 移動中は走るアニメーションを設定
        if(ZombieHP > 0 && zombieRun == true)
        {
            zombie.GetComponent<Animation>().Play(RunAnim.name);
        }

        // ゾンビのHPが0以下になったら死亡アニメーション
        if(ZombieDead == false && ZombieHP <= 0)
        {
            zombie.GetComponent<Animation>().Play(DieAnim.name);
            ZombieDead = true;
            zombie.isStatic = true;
            Invoke("ZombieDestroy", 2.0f);
        }



        if (Input.GetKey(KeyCode.Q))
            zombie.GetComponent<Animation>().Play(IdleAnim.name);

        if (Input.GetKey(KeyCode.R))
            zombie.GetComponent<Animation>().Play(RunAnim.name);

		if (Input.GetKey(KeyCode.T))
			zombie.GetComponent<Animation>().Play(AttackAnim.name);

		if (Input.GetKey(KeyCode.O))
            zombie.GetComponent<Animation>().Play(GetHitAnim.name);
    }

    private void FixedUpdate()
    {

        // ゾンビがフィールドに出現していて死んでいない場合、プレイヤーを向いて追いかける
        if (zombie.activeSelf == true && zombieDeath == false)
        {
            agent.destination = playerPos;
            transform.LookAt(playerPos);
        }
    }

    public void AppearZombie()
    {
        //this.gameObject.SetActive(true);   
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーの攻撃が当たった時はHPが減少、gethitアニメーションを実行
        if (other.gameObject.tag == "AttackEffect")
        {
            ZombieHP -= 15;
            zombieUIManager.DamageByPlayer(ZombieHP);
            // Damaged SEを鳴らす
            audioSource.PlayOneShot(damagedSE);
            // ゾンビが走るのを止めてgethitアニメーション
            zombieRun = false;
            zombie.GetComponent<Animation>().Play(GetHitAnim.name);
            Invoke("RunAgain", 0.8f);
        }
    }

    void RunAgain()
    {
        zombieRun = true;
    }


    void ZombieDestroy()
    {
        Instantiate(deathEffect, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
        // ゾンビが動かないようにする
        zombieDeath = true;
        agent.isStopped = true;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
