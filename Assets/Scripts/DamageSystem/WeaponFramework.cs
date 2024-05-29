using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFramework : MonoBehaviour
{
    protected float damage;
    protected float attackWait;
    protected float attackCooldown;
    public bool canAttack;

    public virtual IEnumerator Attack()
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
