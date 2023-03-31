using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int scene;
    Animator animator;
    bool checkPlayer = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && checkPlayer)
        {

            animator.SetTrigger("Open");
            SceneManager.LoadScene(scene);

            
           
           
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) {
            checkPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            checkPlayer = false;
        }
    }

}
