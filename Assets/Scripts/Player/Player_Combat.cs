using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Animator animator;
    [SerializeField] Transform AttackPoint;
    public float AttackRange = 0.5f;
    [SerializeField] LayerMask enemyLayer;

    int AttackDamage = 40;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Z)){

            Attack();
            
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
