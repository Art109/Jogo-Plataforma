using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealt;
    // Start is called before the first frame update
    [SerializeField] GameObject player;

    [SerializeField] Animator animator;

    void Start()
    {
        currentHealt = maxHealth;
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
            Die();
        }

    }

    void Die()
    {
        //Animacao de Morte
        animator.SetTrigger("Die");

        //Morte
        this.enabled= false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player_Combat>().TakeDamage(1);

            Debug.Log("Acertei o player");
        }
    }
    

}
