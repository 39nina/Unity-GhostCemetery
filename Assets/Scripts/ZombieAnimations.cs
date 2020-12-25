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

	void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
	
	void Update() {

        // プレイヤーの現在地を取得
        playerPos = player.transform.position;

        // 移動中は走るアニメーションを設定
        if(this.GetComponent<NavMeshAgent>().speed > 0)
        {
            zombie.GetComponent<Animation>().Play(RunAnim.name);
        }

        if (Input.GetKey(KeyCode.Q))
            zombie.GetComponent<Animation>().Play(IdleAnim.name);

        if (Input.GetKey(KeyCode.R))
            zombie.GetComponent<Animation>().Play(RunAnim.name);

		if (Input.GetKey(KeyCode.T))
			zombie.GetComponent<Animation>().Play(AttackAnim.name);

		if (Input.GetKey(KeyCode.O))
            zombie.GetComponent<Animation>().Play(GetHitAnim.name);

        if (Input.GetKey(KeyCode.G))
            zombie.GetComponent<Animation>().Play(DieAnim.name);
    }

    private void FixedUpdate()
    {

        // ゾンビがフィールドに出現している場合、プレイヤーを向いて追いかける
        if (zombie.activeSelf == true)
        {
            agent.destination = playerPos;
            transform.LookAt(playerPos);
        }
    }

    public void AppearZombie()
    {
        this.gameObject.SetActive(true);
        
    }
}
