using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    // Start is called before the first frame update

    int currentHealth;

    [SerializeField] Animator animator;
    [SerializeField] Transform AttackPoint;
    public float AttackRange = 0.5f;
    [SerializeField] LayerMask enemyLayer;
    

    int AttackDamage = 40;

    public float AttackRate = 2f;
    float nextAttackTime = 0f;

    public float iFrame = 0.5f;
    float next_iFrame = 0f;


    void Start()
    {
        currentHealth = GameController.vidaAtual;


    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = GameController.vidaAtual;
        if (Time.time >= nextAttackTime) {
            if (Input.GetKeyDown(KeyCode.Z))
            {

                Attack();
                nextAttackTime = Time.time + 1f / AttackRate;

            }
        }

        Die();
       
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

        if (Time.time >= next_iFrame)
        {

            //Reducao de vida
            GameController.vidaAtual -= damage;
            


            //Animacao de dano
            animator.SetTrigger("Hit");

            next_iFrame = Time.time + 1f / iFrame;



        }
        
        

        Debug.Log(currentHealth);
        //Morte
        

    }

    public void Heal()
    {
        if(currentHealth < 3)
        {
            GameController.vidaAtual++;
            
        }
        
        
        
    }

    void Die()
    {
        if (currentHealth <= 0)
        {
            //Animacao de Morte
            animator.SetTrigger("Die");

            //Morte
            this.enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
