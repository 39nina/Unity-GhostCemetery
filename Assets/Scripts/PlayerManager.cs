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
    void OnEventFx(GameObject InEffect)
    {
        GameObject newSpell = Instantiate(InEffect, this.transform);

        Destroy(newSpell, 1.0f);
    }
}
