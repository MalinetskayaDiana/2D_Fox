using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float startHealth;
    public float currentHealth { get; private set; }

    public AudioSource Pain;
    private void Awake()
    {
        currentHealth = startHealth;
    }
    public void TakeHit(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startHealth);
        Pain.Play();
        
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetHealth(float bonusHealth)
    {
        currentHealth = Mathf.Clamp(currentHealth + bonusHealth, 0, startHealth);
        if (currentHealth >= startHealth)
        {
            currentHealth = startHealth;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeHit(1);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetHealth(1);
        }
        
    }
}
