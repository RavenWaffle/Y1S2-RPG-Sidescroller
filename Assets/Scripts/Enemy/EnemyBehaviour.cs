using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : StateMachineBehaviour
{
    protected Rigidbody2D _thisRB;
    protected Character _thisChar;
    protected GameObject target;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _thisRB = animator.gameObject.GetComponent<Rigidbody2D>();
        _thisChar = animator.gameObject.GetComponent<Character>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    protected float DistanceToTarget(Transform Target)
    {
        return Vector2.Distance(_thisRB.gameObject.transform.position, Target.transform.position);
    }

    protected void MoveTo(Transform destination, float speed)
    {
        Vector3 new_destination = new Vector3(destination.position.x, _thisRB.gameObject.transform.position.y, _thisRB.gameObject.transform.position.z);
        _thisRB.velocity = (new_destination - _thisRB.gameObject.transform.position) * speed;
    }
}
