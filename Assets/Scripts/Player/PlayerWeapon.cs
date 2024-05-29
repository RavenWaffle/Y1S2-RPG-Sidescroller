using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(GroundChecker))]
public class PlayerWeapon : MonoBehaviour
{
    private Rigidbody2D _playerRB;
    private PlayerMovement _playerMovement;
    private GroundChecker _groundChecker;

    [SerializeField] private PlayerCrossbow crossbow;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _recoilForce;
    [SerializeField] private float _recoilTime;
    [SerializeField] private float _reloadWalkSpeed;

    private float originalSpeed;
    private bool isRecoil;
    private float reloadHoldTime;
    private float recoilHoldTime;

    private void Awake()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();
        _groundChecker = GetComponent<GroundChecker>();
        originalSpeed = _playerMovement.GetSpeed();
    }

    void Update()
    {
        Shooting();
        Recoil();
    }

    void Shooting()
    {
        if(!crossbow.canAttack)
        {
            _playerMovement.SetSpeed(originalSpeed);
            return;
        }

        if(Input.GetKeyUp(KeyCode.Space) || !_groundChecker.isGrounded)
        {
            reloadHoldTime = 0;
            _playerMovement.SetSpeed(originalSpeed);
        }

        if (Input.GetKey(KeyCode.Space) && _groundChecker.isGrounded && crossbow.canAttack)
        {
            _playerMovement.SetSpeed(_reloadWalkSpeed);
            reloadHoldTime += Time.deltaTime;
            if (reloadHoldTime >= _reloadTime)
            {
                crossbow.Attack();
                isRecoil = true;
                reloadHoldTime = 0;

            }
        }
        else
        {
            reloadHoldTime = 0;
        }
    }

    void Recoil()
    {
        if(isRecoil)
        {
            recoilHoldTime += Time.deltaTime;
            if (recoilHoldTime >= _recoilTime)
            {
                recoilHoldTime = 0;
                isRecoil = false;
            }
            _playerRB.AddForce(_recoilForce * -1 * crossbow.transform.forward, ForceMode2D.Force);
            _playerMovement.SetSpeed(originalSpeed);
        }
    }
}
