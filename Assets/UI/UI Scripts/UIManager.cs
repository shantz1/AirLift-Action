using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public string mainLevel;

    public void StartGame()
    {
        SceneManager.LoadScene(mainLevel);
    }
    public void quitButton()
    {
        Application.Quit();
    }


}
