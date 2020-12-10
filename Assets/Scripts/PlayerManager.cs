using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    float x;
    float z;
    float speed = 4.5f;
    int playerHP = 100;
    [SerializeField] PlayerUIManager playerUIManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * -1 * speed;

        Attack();
    }

    private void FixedUpdate()
    {
        Run();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            // ゴーストに攻撃されたときアニメーションを変更
            animator.SetTrigger("Damage");
            // ゴーストから攻撃を受けた分だけHPを減らし、HPゲージにも反映
            playerHP -= GhostManager.ghostAttack;
            playerUIManager.DamageByGhost(playerHP);
        }
    }

    // 移動時のアニメーション
    void Run()
    {
        rb.velocity = new Vector3(x, 0, z);
        animator.SetFloat("Speed", rb.velocity.magnitude);
    }

    // 攻撃時のアニメーション
    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            animator.SetTrigger("Attack");
        }
    }

    // 攻撃時にエフェクトを生成
    void OnEventFx(GameObject effect)
    {
        GameObject fire = Instantiate(effect, this.transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);

        Destroy(fire, 1.0f);
    }
}
