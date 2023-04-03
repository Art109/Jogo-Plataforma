using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static int totalScore = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private Image[] vida;


   
    public static int vidaAtual = 3;
    int vidaMaxima = 3;

  
    // Start is called before the first frame update
    void Start()
    {
     
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
        for(int i = 0; i < vidaMaxima; i++)
        {
            vida[i].enabled= false;
        }

        for (int i = 0; i < vidaAtual ; i++){
            vida[i].enabled = true;
        }
        
    
    }
    

    public static void TrocaCena(int cena)
    {
        SceneManager.LoadScene(cena);
    }

    public static void Reset()
    {
        totalScore= 0;
        vidaAtual= 3;
        Time.timeScale = 1;
    }
}
