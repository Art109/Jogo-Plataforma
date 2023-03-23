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

    float explosionRange = 0.5f;
    int explosionDamage = 60;
    [SerializeField] LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
       
        
            RB.velocity = new Vector2(-speed, RB.velocity.y);
        


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

        //Detecta o player que foi atingido
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(transform.position, explosionRange, playerLayer);

        //Causa dano
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Player_Combat>().TakeDamage(explosionDamage);
            Debug.Log("Acertei o" + player.name);
        }



        //Destroi objeto
        Destroy(eu, 0.15f);

    }
}
