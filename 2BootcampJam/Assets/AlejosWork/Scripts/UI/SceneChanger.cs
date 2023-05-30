using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public bool canPause;
    [SerializeField]
    private GameObject pauseMenu;
    private static bool isPaused;
    private void Awake()
    {
        SceneAwaker();
    }
    private void Update()
    {
        if (canPause && Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pause Method");
            ScenePauser();
        }
    }
    public void SceneMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SceneGame()
    {
        isPaused = false;
        SceneManager.LoadScene("Scene1");
    }
    public void SceneDefeat()
    {
        SceneManager.LoadScene("DefeatScreen");
    }
    public void ScenePauser()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }         
    }

    public void SceneAwaker()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
}
