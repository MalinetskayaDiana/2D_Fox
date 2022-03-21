using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gems : MonoBehaviour
{
    public static int TheGem;
    public Text CountGem;
    
    void Start()
    {
        CountGem = GetComponent<Text>();
    }

    void Update()
    {
        CountGem.text = "X" + TheGem;
    }
}
