using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_ : MonoBehaviour
{
    [SerializeField]Transform ShotPoint;
    float ShootRate = 0.25f;
    float nextShootTime = 0f;
    [SerializeField] Animator animator;
    [SerializeField] GameObject cannonBall;
    
    
    

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextShootTime)
        {

                Shoot();
                nextShootTime = Time.time + 1f / ShootRate;
                
             
            
        }

        
        
    }

    void Shoot()
    {
        //Animação de tiro
        animator.SetTrigger("Shoot");

        //Instancia o tiro
        Instantiate(cannonBall, ShotPoint.position, Quaternion.identity);
    }
}
