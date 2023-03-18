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

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        meuRB= GetComponent<Rigidbody2D>();
        
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

        meuRB.velocity = new Vector2(movimento, meuRB.velocity.y);

        Flip();

        Jump();
    }

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
        if( Input.GetButtonDown("Jump") && isGrounded())
        {
            meuRB.velocity = new Vector2(meuRB.velocity.x, jumpPower);
        }
        if(Input.GetButtonUp("Jump") && meuRB.velocity.y > 0f)
        {
            meuRB.velocity = new Vector2(meuRB.velocity.x, meuRB.velocity.y * 0.5f);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
