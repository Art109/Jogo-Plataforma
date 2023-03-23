using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    // Start is called before the first frame update

    public int maxHealth = 100;
    int currentHealth;

    [SerializeField] Animator animator;
    [SerializeField] Transform AttackPoint;
    public float AttackRange = 0.5f;
    [SerializeField] LayerMask enemyLayer;

    int AttackDamage = 40;

    public float AttackRate = 2f;
    float nextAttackTime = 0f;


    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time >= nextAttackTime) {
            if (Input.GetKeyDown(KeyCode.Z))
            {

                Attack();
                nextAttackTime = Time.time + 1f / AttackRate;

            }
        }
       
    }

    void Attack()
    {   
        //Roda a animação do Ataque
        animator.SetTrigger("Attack");

        //Detecta os inimigos atingidos
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayer);

        //Causa dano
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(AttackDamage);
            Debug.Log("Acertei o" + enemy.name);
        }




    }

    public void TakeDamage(int damage)
    {
        //Reducao de vida
        currentHealth -= damage;

        //Animacao de dano
        animator.SetTrigger("Hit");

        Debug.Log(currentHealth);
        //Morte
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        //Animacao de Morte
        animator.SetTrigger("Die");

        //Morte
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
