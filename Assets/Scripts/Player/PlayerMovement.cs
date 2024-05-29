using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _playerRB;
    private GroundChecker _groundChecker;

    [Header("Movement")]
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float JumpForce;

    private void Awake()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
    }

    private void Update()
    {
        PlayerMove();
    }

    //movements
    private void PlayerMove()
    {
        _playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MovementSpeed, _playerRB.velocity.y);

        if (_groundChecker.isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            _playerRB.AddForce(JumpForce * new Vector2(0, 1), ForceMode2D.Impulse);
        }

        if(Input.GetAxisRaw("Horizontal") == -1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(Input.GetAxisRaw("Horizontal") == 1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public float GetSpeed()
    {
        return MovementSpeed;
    }

    public void SetSpeed(float change)
    {
        MovementSpeed = change;
    }
}
