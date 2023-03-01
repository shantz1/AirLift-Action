using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialPanels;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject takedownCounter;
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject firingButton;
    [SerializeField] private GameObject healthBar;
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
            pauseButton.SetActive(true);
            takedownCounter.SetActive(true);
            joystick.SetActive(true);
            firingButton.SetActive(true);
            healthBar.SetActive(true);

        }
        else
        {
            ShowTutorial();
            pauseButton.SetActive(false);
            takedownCounter.SetActive(false);
            joystick.SetActive(false);
            firingButton.SetActive(false);
            healthBar.SetActive(false);
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
        pauseButton.SetActive(true);
        takedownCounter.SetActive(true);
        joystick.SetActive(true);
        firingButton.SetActive(true);
        healthBar.SetActive(true);
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
            pauseButton.SetActive(true);
            takedownCounter.SetActive(true);
            joystick.SetActive(true);
            firingButton.SetActive(true);
            healthBar.SetActive(true);
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
            pauseButton.SetActive(false);
            takedownCounter.SetActive(false);
            joystick.SetActive(false);
            firingButton.SetActive(false);
            healthBar.SetActive(false);
        }
        else
        {
            tutorialActive = false;
            Time.timeScale = previousTimeScale;
            pauseButton.SetActive(true);
            takedownCounter.SetActive(true);
            joystick.SetActive(true);
            firingButton.SetActive(true);
            healthBar.SetActive(true);
        }
    }
}