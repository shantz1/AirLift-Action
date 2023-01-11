using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int score = 0;
    public int enemyKills;
    public bool gameOver = false;
    public UIManager uiManager;

     public void ScoreIncrement()
    {
        score += 1;
        uiManager.SetScoreText(score);
        if(score == enemyKills)
        {
            gameOver = true;
        }
    }

}
