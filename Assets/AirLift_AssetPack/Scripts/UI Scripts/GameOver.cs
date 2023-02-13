using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public Health healthscript;
    public GameObject GameoverUI;
    public GameObject pauseButton;
    
    // Start is called before the first frame update
    void Awake()
    {
        GameoverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if(healthscript.gameOver)
        {
            GameoverUI.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 0f;
        }
        
       
    }
}
