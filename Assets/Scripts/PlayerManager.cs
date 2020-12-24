using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    AudioSource audioSource;
    float x;
    float z;
    float speed = 4.5f;
    int playerHP = 100;
    Vector3 diff;
    Vector3 latestPos;
    [SerializeField] GameObject cane = default;
    [SerializeField] PlayerUIManager playerUIManager = default;
    [SerializeField] AudioClip playerDamagedSE = default;
    [SerializeField] Camera mainCamera = default;
    Vector3 cameraForward;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        latestPos = this.transform.position;
    }

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * -1 * speed;

        Attack();

        // 前回のフレームから進んだベクトル方向を取得し、次のフレームでのチェックのために現在地をlatestPosに代入
        diff = transform.position - latestPos;
        latestPos = transform.position;

        // 残りHPが0以下になったらゲームオーバー
        if(playerHP <= 0)
        {
            GameOver();
        }
    }

    private void FixedUpdate()
    {
        Run();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ghost")
        {
            // ゴーストに攻撃されたときアニメーションを変更
            animator.SetTrigger("Damage");
            // ダメージ音を再生
            audioSource.PlayOneShot(playerDamagedSE);
            // ゴーストから攻撃を受けた分だけHPを減らし、HPゲージにも反映
            playerHP -= GhostManager.ghostAttack;
            playerUIManager.DamageByGhost(playerHP);
        }
    }

    // 移動
    void Run()
    {
        // カメラの方向取得
        cameraForward = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1).normalized);
        // カメラの向きと入力値から移動方向決定
        Vector3 moveForward = -cameraForward * z + -mainCamera.transform.right * x;
        // プレイヤーの移動
        rb.velocity = moveForward;

        // 移動時のアニメーション
        animator.SetFloat("Speed", rb.velocity.magnitude);
        // 移動ベクトルが0.01以上の時に体の向きを変える 
        if(diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }
    }

    // 攻撃時のアニメーション
    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            animator.SetTrigger("Attack");
        }
    }

    // 攻撃中は移動できないようにする
    public void StopMove()
    {
        speed = 0;
    }
    public void StartMove()
    {
        speed = 4.5f;
    }

    // 攻撃時にエフェクトを生成
    void OnEventFx(GameObject effect)
    {
        GameObject fire = Instantiate(effect, this.transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);

        Destroy(fire, 1.0f);
    }

    // キャンドル点灯時のアクション

    public void LightCandle()
    {
        animator.SetTrigger("Light");
    }

    // プレイヤーの死亡アニメーション
    void GameOver()
    {
        playerHP = 0;
        animator.SetTrigger("Die");
        Invoke("Destroy", 1.0f);
    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }

    // 死亡時に杖だけ残すため、親子関係を解除して本体は削除
    public void RemainCane()
    {
        cane.transform.parent = GameObject.Find("DieCaneParent").transform;
    }
}
