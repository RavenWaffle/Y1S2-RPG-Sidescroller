using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentRotate : MonoBehaviour
{
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
