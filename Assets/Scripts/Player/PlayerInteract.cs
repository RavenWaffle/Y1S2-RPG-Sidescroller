using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] float _InteractRadius;
    [SerializeField] LayerMask _playerLayer;
    private void Update()
    {
        Interact(GetClosest());
    }

    Interactable GetClosest()
    {
        Collider2D[] candidates = Physics2D.OverlapCircleAll(transform.position, _InteractRadius, ~_playerLayer);
        foreach (Collider2D c in candidates)
        {
            c.TryGetComponent<Interactable>(out Interactable active);
            if (active != null)
            {
                if (Physics2D.Raycast(transform.position, active.gameObject.transform.position - transform.position, ~_playerLayer))
                {
                    return active;
                }
            }
        }
        return null;
    }

    private void Interact(Interactable target)
    {
        if(target != null)
        {
            if(Input.GetKeyDown(target.InteractKey))
            {
                target.Interact(this.gameObject);
            }
        }
    }
}
