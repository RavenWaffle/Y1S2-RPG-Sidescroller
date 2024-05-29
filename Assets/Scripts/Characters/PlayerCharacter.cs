using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    [SerializeField] private float _maxStamina;
    [SerializeField] private float _staminaRegen;
    private float stamina;

    [HideInInspector] public bool canSetStamina = true;
    [HideInInspector] public bool canRegen = true;
    public PlayerCharacter()
    {
        _maxHealth = 100;
        _maxStamina = 100;
        health = _maxHealth;
        stamina = _maxStamina;
    }

    private void Update()
    {
        if(canRegen)
        {
            SetStamina(GetStamina() + _staminaRegen * Time.deltaTime);
            Debug.Log(stamina);
        }
    }

    public float GetStamina()
    {
        return stamina;
    }

    public void SetStamina(float change)
    {
        if(canSetStamina)
        {
            stamina = change;
            stamina = Mathf.Clamp(stamina, 0, _maxStamina);
        }
    }
}
