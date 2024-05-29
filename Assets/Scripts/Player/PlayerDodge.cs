using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerCharacter))]
public class PlayerDodge : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerCharacter _playerCharacter;

    [SerializeField] float _dodgeCost;
    [SerializeField] float _dodgeRestTime;
    [SerializeField] float _dodgeTime;
    [SerializeField] float _dodgeSpeed;

    private float originalSpeed;
    private bool isDodge;
    private float DodgeHoldTime;
    private float RestHoldTime;

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
        //if is dodging, do dodge, if not, wait for input
        if(isDodge)
        {        
            //initial set up
            _playerMovement.SetSpeed(_dodgeSpeed);
            _playerCharacter.canSetHealth = false;

            //start dodge timer
            DodgeHoldTime += Time.deltaTime;
            if (DodgeHoldTime >= _dodgeTime)
            {
                _playerMovement.SetSpeed(originalSpeed);
                _playerCharacter.canSetHealth = true;

                //start rest timer
                RestHoldTime += Time.deltaTime;
                if (RestHoldTime > _dodgeRestTime)
                {
                    DodgeHoldTime = 0;
                    RestHoldTime = 0;
                    _playerMovement.SetSpeed(originalSpeed);
                    _playerCharacter.canRegen = true;
                    isDodge = false;
                }
            }
        }
        else
        {
            //if doesnt have the stamina, ignore all input
            if(_playerCharacter.GetStamina() < _dodgeCost)
            {
                return;
            }

            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                isDodge = true;
                _playerCharacter.SetStamina(_playerCharacter.GetStamina() - _dodgeCost);
                _playerCharacter.canRegen = false;
            }
        }
    }
}
