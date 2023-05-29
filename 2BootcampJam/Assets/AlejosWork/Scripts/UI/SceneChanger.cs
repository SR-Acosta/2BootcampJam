using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SceneGame()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void SceneDefeat()
    {
        SceneManager.LoadScene("DefeatScreen");
    }
}
