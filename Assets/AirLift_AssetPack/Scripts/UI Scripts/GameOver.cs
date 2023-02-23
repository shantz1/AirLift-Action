using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public Health healthscript;
    public GameObject GameoverUI;
    public GameObject pauseButton;
    public HelicoptorCollider hc;
    
    // Start is called before the first frame update
    void Awake()
    {
        GameoverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hc.gameOver)
        {
            GameoverUI.SetActive(true);
            pauseButton.SetActive(false);
            StartCoroutine(WaitBeforeDie());
            AudioManager.instance.pauseSounds();
            SoundManager.Instance.PlaySound(SoundManager.Instance.gameOver);
        }
        if(healthscript.gameOver)
        {
            GameoverUI.SetActive(true);
            pauseButton.SetActive(false);
            StartCoroutine(WaitBeforeDie());
            AudioManager.instance.pauseSounds();
            SoundManager.Instance.PlaySound(SoundManager.Instance.gameOver);

        }




    }

    public IEnumerator WaitBeforeDie()
    {
        
        yield return new WaitForSeconds(2f);
        OnDie();
    
    }
    
    public void OnDie()
    {
        Time.timeScale = 0f;
    }


}
