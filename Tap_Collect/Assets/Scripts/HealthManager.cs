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
        }
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        healthText.gameObject.SetActive(false);
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
        healthText.gameObject.SetActive(true);
        currentHealth = maxHealth;
        UpdateHealthUI();
    }
  
    public void HideHealth()
    {
        healthText.gameObject.SetActive(false);
    }
}
