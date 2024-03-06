using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] FloatingHealthBar healthBar;
    private UIManager uIManager;
    public bool isAlive = true;
    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        healthBar.UpdateHealthBar(currentHealth,maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!isAlive) return;
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        Debug.Log(currentHealth.ToString());
        if (currentHealth <= 0) {
            Die();
         }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("isDeath");
        isAlive = false;
        uIManager.GameOver();
    }
   
}
