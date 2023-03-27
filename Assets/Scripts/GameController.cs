using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int totalScore = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private Image[] vida;

    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance= this;
    }

    // Update is called once per frame
    void Update()
    {
        updateScore();
        updateVida();
    }

    public void updateScore()
    {
        scoreText.text = totalScore.ToString();
    }

    public void updateVida()
    {
        
    }

    public void addVida(int vida)
    {
        if(vida < 3)
        {
            this.vida[vida].enabled = true;
        }
        
    }
                    
    public void removeVida(int vidaAtual,int vidaMaxima)
    {

        for (int i = vidaMaxima; i > vidaAtual ; --i){
            vida[i-1].enabled = false;
        }
        
    
    }
}
