using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helf : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private AudioClip playerDamagedSound;
    [SerializeField] private GameObject[] fullHealths;
    public int currentHealth;
    [SerializeField] private GameObject lossScreen;
    [SerializeField] private GameObject inGameUI;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        Debug.Log(currentHealth);
        if (gameObject.CompareTag("Player"))
        {
            fullHealths[currentHealth].SetActive(false);
        }
        if (currentHealth > 0 && gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(playerDamagedSound);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void AddHealth()
    {
        if (currentHealth == 5) return;
        currentHealth += 1;
        fullHealths[currentHealth - 1].SetActive(true);
    }

    public void UpdateUI()
    {
        for (int i = maxHealth - 1; i >= 0; i--)
        {
            if (currentHealth <= i)
            {
                fullHealths[i].SetActive(false);
            }
        }
    }

    public void Die()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Player"))
        {
            inGameUI.SetActive(false);
            lossScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
        }
    }
}
