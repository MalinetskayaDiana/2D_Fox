using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHeart;
    [SerializeField] private Image currentHeart;
    void Start()
    {
        totalHeart.fillAmount = playerHealth.currentHealth / 10;
    }

   
    void Update()
    {
        currentHeart.fillAmount = playerHealth.currentHealth / 10;
    }
}
