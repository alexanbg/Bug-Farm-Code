using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject pauseOptions;
    [SerializeField]
    private GameObject dairy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Back()
    {
        pauseOptions.SetActive(true);
        dairy.SetActive(false);
    }
    public void OpenDairy()
    {
        pauseOptions.SetActive(false);
        dairy.SetActive(true);
    }

}
