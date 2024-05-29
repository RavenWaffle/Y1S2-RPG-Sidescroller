using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float attackWait;
    [SerializeField] protected float attackCooldown;
    public bool canAttack;

    public void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }

    protected virtual IEnumerator AttackCoroutine()
    {
        //to copy and paste mostly
        if(!canAttack)
        {
            yield return null;
        }

        yield return new WaitForSeconds(attackWait);
        canAttack = false;

        //attack
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;

        yield return null;
    }
}
