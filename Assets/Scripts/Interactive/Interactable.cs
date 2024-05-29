using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public KeyCode InteractKey;

    public virtual void Interact(GameObject user)
    {
        if(Input.GetKeyDown(InteractKey))
        {
            //do stuff
        }
    }

    protected GameObject FindPlayer()
    {
        return GameObject.Find("PlayerParent");
    }
}
