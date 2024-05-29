using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerCrossbow : WeaponFramework
{
    [SerializeField] private LayerMask[] targetMask;

    public PlayerCrossbow()
    {
        damage = 66;
        attackCooldown = 1f;
        attackWait = 0;
    }

    public override IEnumerator Attack()
    {
        Debug.Log("crossbow attack");
        if (!canAttack)
        {
            yield return null;
        }

        yield return new WaitForSeconds(attackWait);
        canAttack = false;

        //Single target
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, transform.forward, 25);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }
        foreach (LayerMask layer in targetMask)
        {
            if(layer == 1 << hit.collider.gameObject.layer)
            {
                Debug.Log(hit.collider.gameObject.name + "is target");
                hit.collider.gameObject.TryGetComponent<Character>(out Character target);
                target?.SetHealth(target.GetHealth() - damage);
            }
        }

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;

        yield return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * 25);
    }
}
