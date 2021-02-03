using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackManager : MonoBehaviour
{
    // 武器がプレイヤーに当たったら、武器のisTriggerをfalseにする
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.GetComponent<MeshCollider>().isTrigger = true;
        }
    }
}
