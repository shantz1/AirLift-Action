using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour

{
    [SerializeField] private GameObject[] tutorialPanels;
    private bool[] hasShownTutorial;
    private int currentFunctionality = 0;
    private bool tutorialActive = false;
    private float previousTimeScale = 1f;
    

   
    
    void Start()
    {
        // Initialize the hasShownTutorial array
        hasShownTutorial = new bool[tutorialPanels.Length];
        for (int i = 0; i < tutorialPanels.Length; i++)
        {
            if (PlayerPrefs.GetInt("hasShownTutorial" + i) == 1)
            {
                hasShownTutorial[i] = true;
            }
        }

        // Check if the player has already seen the tutorial for the current functionality
        if (hasShownTutorial[currentFunctionality])
        {
            tutorialActive = false;
            Time.timeScale = previousTimeScale;
        }
        else
        {
            ShowTutorial();
        }
    }

    void ShowTutorial()
    {
        
        tutorialActive = true;
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0;
        tutorialPanels[currentFunctionality].SetActive(true);
       
    }

    public void HideTutorial()
    {
        tutorialPanels[currentFunctionality].SetActive(false);
        hasShownTutorial[currentFunctionality] = true;
        PlayerPrefs.SetInt("hasShownTutorial" + currentFunctionality, 1);
        PlayerPrefs.Save();
        tutorialActive = false;
        Time.timeScale = previousTimeScale;
       
    }

    public void NextFunctionality()
    {
        // Hide the current tutorial panel and move on to the next functionality
        tutorialPanels[currentFunctionality].SetActive(false);
        currentFunctionality++;

        // Show the tutorial for the next functionality if the player hasn't seen it yet
        if (currentFunctionality < tutorialPanels.Length && !hasShownTutorial[currentFunctionality])
        {
            ShowTutorial();
        }
        else
        {
            tutorialActive = false;
            Time.timeScale = previousTimeScale;
        }
    }

    public void SkipTutorial()
    {
        // Hide the current tutorial panel and mark the tutorial as shown for the current functionality
        tutorialPanels[currentFunctionality].SetActive(false);
        hasShownTutorial[currentFunctionality] = true;
        PlayerPrefs.SetInt("hasShownTutorial" + currentFunctionality, 1);
        PlayerPrefs.Save();

        // Move on to the next functionality if there is one
        currentFunctionality++;
        if (currentFunctionality < tutorialPanels.Length)
        {
            ShowTutorial();
        }
        else
        {
            tutorialActive = false;
            Time.timeScale = previousTimeScale;
        }
    }
}