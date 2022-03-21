using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    int levelUnclock;
   
    void Start()
    {
        levelUnclock = PlayerPrefs.GetInt("level", 1);
        for (int i = 0; i< buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < levelUnclock; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void LevelLoad(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
