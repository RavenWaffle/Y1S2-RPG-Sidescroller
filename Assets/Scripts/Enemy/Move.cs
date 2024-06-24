using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : EnemyBehaviour
{
    [SerializeField] float Speed = 10;
    [SerializeField] float Range = 10;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        target = GameObject.Find("PlayerParent");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(DistanceToTarget(target.transform) <= Range)
        {
            _thisRB.velocity = Vector2.zero;
            animator.SetTrigger("Attack");
        }
        else
        {
            MoveTo(target.transform, Speed);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
