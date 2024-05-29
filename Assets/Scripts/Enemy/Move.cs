using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : EnemyBehaviour
{
    [SerializeField] float Speed = 10;
    [SerializeField] float Range = 10;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MoveTo(target.transform, Speed);
        if(DistanceToTarget(target.transform) <= Range)
        {
            animator.SetTrigger("Attack");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
