using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedBehaviour : StateMachineBehaviour
{
    // 攻撃を受けている間、回転しないようにする
    Vector3 currentPosition;
    Quaternion currentRotation;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentPosition = animator.transform.position;
        currentRotation = animator.transform.rotation;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = currentPosition;
        animator.transform.rotation = currentRotation;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = currentPosition;
        animator.transform.rotation = currentRotation;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
