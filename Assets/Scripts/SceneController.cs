using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private int scene;

    [SerializeField] private bool gameOver, gameFail;


    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeScene();

        }
    }

    public void ChangeScene()
    {
        int i;
        if (gameFail || gameOver)
            for ( i = scene; i <= SceneManager.sceneCountInBuildSettings; i++ )
            {
                do
                {
                    SceneManager.LoadScene(i);
                    break;
                }
                while (i == SceneManager.sceneCountInBuildSettings);
            }

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(scene);
    }

}
