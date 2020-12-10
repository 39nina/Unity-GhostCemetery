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

    // ゴーストに攻撃されたときアニメーションを変更
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            animator.SetTrigger("Damage");
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
        GameObject newSpell = Instantiate(effect, this.transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);

        Destroy(newSpell, 1.0f);
    }
}
