using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 0;
        maxHealth = 100;
        currentHealt = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = rb.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }
}
