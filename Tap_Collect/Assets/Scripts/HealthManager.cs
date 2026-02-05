using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    [SerializeField] private int maxHealth = 100;
    [SerializeField] public int currentHealth;
    [SerializeField] public TextMeshProUGUI healthText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentHealth = maxHealth;
            healthText.text = "Health:" + currentHealth;
        }
        else
            Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthUI();

        if (currentHealth == 0)
        {
            GameManager.instance.GameOver();
            Debug.Log("Game Over");
        }
    }
    void UpdateHealthUI()
    {
        healthText.text = "Health: " + currentHealth;
    }
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }
}
