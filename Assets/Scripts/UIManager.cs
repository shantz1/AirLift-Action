using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void SetScoreText(int score)
    {
        scoreText.text = "Score : " + score;
    }
}
