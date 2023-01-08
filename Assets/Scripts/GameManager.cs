using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int score;

     public void ScoreIncrement()
    {
        score += 1;
    }

}
