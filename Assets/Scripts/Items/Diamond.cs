using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Diamond : MonoBehaviour
{

    public int Score = 10;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            GameController.instance.totalScore += Score;
            //GameController.instance.updateScore();
        }
    }

}




  