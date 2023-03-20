using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealt;
    // Start is called before the first frame update

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

}
