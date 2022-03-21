using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReturnMenu : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }
}
