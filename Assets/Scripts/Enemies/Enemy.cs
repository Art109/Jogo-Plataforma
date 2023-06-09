using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{

    public int maxHealth;
    protected int currentHealt;
    // Start is called before the first frame update
    [SerializeField] protected GameObject player;

    protected Animator animator;


    //Movimento + IA simples
    protected Rigidbody2D rb;
    [SerializeField] protected float speed = 2f;
    [SerializeField] bool isRight = false;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    protected int damage;
   

    void Start()
    {
  
    }

    void Update()
    {
 
    }



    public virtual void Movimento()
    {
        animator.SetBool("Run", true);
        if(isRight)
        {
            rb.velocity = new Vector2(speed,rb.velocity.y);
        }
        if (!isRight)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }


        if (!isGrounded())
        {
            Flip();
        }
        
        
        
    }

    protected void Flip()
    {
        if (isRight && rb.velocity.x > 0 || !isRight && rb.velocity.x < 0)
        {
            Vector2 localScale = transform.localScale;
            isRight = !isRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }




    public void TakeDamage(int damage)
    {
        //Reducao de vida
        currentHealt -= damage;

        //Animacao de dano
        animator.SetTrigger("Hit");

        Debug.Log(currentHealt);
        //Morte
        if(currentHealt <=0)
        {
            animator.SetTrigger("Die");
        }

    }

    public virtual void Die()
    {
        

        //Morte
        Destroy(gameObject);
        //this.enabled= false;
        //GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player_Combat>().TakeDamage(damage);

            Debug.Log("Acertei o player");
        }
    }



    

}
