using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : Interactable
{
    [SerializeField] Transform _target;

    Doorway()
    {
        InteractKey = KeyCode.E;
    }

    public override void Interact(GameObject user)
    {
        user.transform.position = _target.position;
    }
}
