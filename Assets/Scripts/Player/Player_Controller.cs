using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // RB e velocidade para o movimento;
    private Rigidbody2D meuRB;
    private float speed = 5f;
    private float jumpPower = 10f;

    //Controladores de Movimento
    float movimento;
    private bool isFacingRight = true;

    //Controlador de pulo
    private bool isJumping = false;

    //Controlador de Animação
    private Animator animator;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    
    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();

    }



    void Movimento()
    {

        //Movimento Horizontal
        movimento = Input.GetAxis("Horizontal") * speed;

        meuRB.velocity = new Vector2(movimento , meuRB.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(movimento));

        Flip();

        Jump();
    }

    //Vira o personagem para a direção que esta olhando
    void Flip() {
        if( isFacingRight && movimento < 0 || !isFacingRight && movimento > 0)
        {
            Vector2 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
        
    }
    
    void Jump()
    {
        
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            meuRB.velocity = new Vector2(meuRB.velocity.x, jumpPower);
            isJumping = true;
   
 

        }

        if (Input.GetButtonUp("Jump") && meuRB.velocity.y > 0f)
        {
            meuRB.velocity = new Vector2(meuRB.velocity.x, meuRB.velocity.y * 0.5f);
 
        }


        //Pulo Duplo
        if (isJumping && !isGrounded())
        {
            if(Input.GetButtonDown("Jump"))
            {
                meuRB.velocity = new Vector2(meuRB.velocity.x, jumpPower);
                isJumping = false;

                
            }

            
        }

        //Controle animação de pulo
        if (isGrounded())
        {
            animator.SetBool("Falling", false);
            animator.SetBool("Grounded", true);
        }
        else
        {
            animator.SetBool("Falling", true);
            animator.SetBool("Grounded", false);
        }
        
    }

    

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
