using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerCharacter))]
public class PlayerDodge : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerCharacter _playerCharacter;

    [SerializeField] float _dodgeTime;
    [SerializeField] float _dodgeSpeed;

    private float originalSpeed;
    private bool isDodge;
    private float DodgeHoldTime;

    void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerCharacter = GetComponent<PlayerCharacter>();
        originalSpeed = _playerMovement.GetSpeed();
    }

    void Update()
    {
        Dodge();
    }

    void Dodge()
    {
        if(isDodge)
        {
            _playerMovement.SetSpeed(_dodgeSpeed);
            _playerCharacter.canSetHealth = false;
            DodgeHoldTime += Time.deltaTime;
            if (DodgeHoldTime >= _dodgeTime)
            {
                isDodge = false;
                DodgeHoldTime = 0;
                _playerMovement.SetSpeed(originalSpeed);
                _playerCharacter.canSetHealth = true;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                isDodge = true;
            }
        }
    }
}
