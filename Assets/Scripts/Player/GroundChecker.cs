using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] //groundcheck setup, must be trigger
public class GroundChecker : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] private LayerMask _playerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != _playerLayer)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer != _playerLayer)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != _playerLayer)
        {
            isGrounded = false;
        }
    }
}
