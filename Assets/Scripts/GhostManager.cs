using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    [SerializeField] GameObject player = default;
    [SerializeField] GameObject ghost = default;
    float distance;
    Vector3 ghostPos;
    Animator animator;
    GameObject effect;

    private void Awake()
    {
        ghostPos = ghost.transform.position;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        ghost.SetActive(false);
    }

    private void Update()
    {
        // プレイヤーとの距離を計測
        distance = (player.transform.position - ghostPos).magnitude;

        if (ghost) // 死亡アニメーション以降はチェックしないようにするため
        {
            Appear();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "AttackEffect")
        {
            animator.SetTrigger("Death");
        }
    }

    // 距離が一定以下になったら出現
    void Appear()
    {
        if(distance <= 7)
        {
            ghost.SetActive(true);
        }
    }

    // ダメージを食らったら、dieアニメーション終に自身をdestroyする
    public void GhostDie(GameObject deathEffect)
    {
        effect = Instantiate(deathEffect, this.transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);
        // エフェクト、サウンドの実行完了のため、ゴースト本体のみ先に消滅させる
        Destroy(ghost);
        // 数秒後に付属アイテム含めすべてdestroy
        Invoke("DestroyGhostAll", 4.0f);
    }

    void DestroyGhostAll()
    {
        Destroy(this.gameObject);
        Destroy(effect);
    }
}
