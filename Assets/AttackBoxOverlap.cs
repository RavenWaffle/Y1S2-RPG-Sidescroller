using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxOverlap : EnemyBehaviour
{
    [SerializeField] float Speed = 10;
    [SerializeField] float Range = 10;
    [SerializeField] GameObject _damageBox;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _damageBox.SetActive(true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (DistanceToTarget(target.transform) <= Range)
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
        _damageBox.SetActive(true);
        animator.ResetTrigger("Attack");
    }
}
