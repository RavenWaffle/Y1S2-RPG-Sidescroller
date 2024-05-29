using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected float health;
    public bool canSetHealth = true; 
    public float GetHealth()
    {
        return health;
    }

    public virtual void SetHealth(float change)
    {
        if(canSetHealth)
        {
            health = change;
            Debug.Log(health);
        }

    }
}
