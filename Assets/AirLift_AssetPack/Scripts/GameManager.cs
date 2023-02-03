using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField]
   private  int score = 0;
    
    public void ScoreIncrease()
    {
        score += 10;
    }

    

}
