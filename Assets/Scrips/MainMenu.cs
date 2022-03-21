using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public bool chooseLevel;
    public GameObject menuLevel;
    
    public void BackToMainMemu()
    {
        menuLevel.SetActive(false);
        Time.timeScale = 1f;
        chooseLevel = false;
    }

    public void LevelChoice()
    {
        menuLevel.SetActive(true);
        Time.timeScale = 0f;
        chooseLevel = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game was over");
    }
}
