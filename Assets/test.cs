using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] Transform[] poss;
    [SerializeField] float speed;

    int Counter;
    public Rigidbody2D rb;

    void Start()
    {
        this.transform.position = poss[0].position;    
    }
    void FixedUpdate()
    {
        rb.velocity = (poss[(Counter + 1) % poss.Length].position - poss[Counter % poss.Length].position) * speed;
        if (Vector2.Distance(this.transform.position, poss[(Counter + 1) % poss.Length].position) < 0.25f)
        {
            this.transform.position = poss[(Counter + 1) % poss.Length].position;
            Counter++;
        }
    }
}
