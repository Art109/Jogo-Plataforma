using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update


    
    void Start()
    {
        
        GameController.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        //Editor
        //UnityEditor.EditorApplication.isPlaying= false;
        //Compilado
        Application.Quit();
    }
}
