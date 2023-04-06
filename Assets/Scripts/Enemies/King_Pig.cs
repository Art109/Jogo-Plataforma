using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King_Pig : Enemy
{

    //Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        damage = 3;
        maxHealth = 1000000;
        currentHealt = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = rb.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();

        if(Input.GetKey(KeyCode.K))
        {
            //Animacao de Morte
            animator.SetTrigger("Die");
        }
    }

    public override void Movimento()
    {
        animator.SetBool("Run", true);
        if (player.GetComponent<Transform>().position.x > transform.position.x ) {
            rb.velocity = new Vector2(speed, 0);
        }
        if (player.GetComponent<Transform>().position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        Flip();
    }

    public override void Die()
    {
        GameController.TrocaCena(0);
    }

   

    
}
