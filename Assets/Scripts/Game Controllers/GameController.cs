using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        
    }

    public void RestartGame()
    {
        Invoke("Restarting", 2f);

    }
    public void Restarting()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void homeReturn()
    {
        SceneManager.LoadScene("MainMenu");
    }
    


}
