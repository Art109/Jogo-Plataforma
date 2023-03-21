using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    Rigidbody2D RB;
    Animator animator;
    float speed = 20f;
    [SerializeField] GameObject eu;
    [SerializeField] GameObject canhao;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
       
        
            RB.velocity = new Vector2(speed, RB.velocity.y);
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }


    void Explode()
    {
        //Animação de explosão
        animator.SetTrigger("Explode");

        //Destroi objeto
        Destroy(eu, 0.15f);

    }
}
