using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    float health;
    bool flashing;
    float timer = 0f;
    public Slider healthSlider;
    public CanvasGroup redScreen;
    public GameObject deathPrefab;

    void OnEnable()
    {
        health = maxHealth;
    }

    void StartFlashing()
    {
        flashing = true;
        timer = 0f;
    }

    public void TakeDamage(float delta)
    {
        health -= delta;
        healthSlider.value = health / maxHealth;
            if (health <= 0)
            {
               Destroy(gameObject);
            }
        
    }

    void OnDestroy()
    {
        Instantiate(deathPrefab, transform.position, transform.rotation);
    }
}
