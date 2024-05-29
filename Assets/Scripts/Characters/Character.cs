using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float _maxHealth;
    protected float health;

    [HideInInspector] public bool canSetHealth = true; 
    public float GetHealth()
    {
        return health;
    }

    public virtual void SetHealth(float change)
    {
        if(canSetHealth)
        {
            health = change;
            health = Mathf.Clamp(health, 0, _maxHealth);
        }

    }
}
