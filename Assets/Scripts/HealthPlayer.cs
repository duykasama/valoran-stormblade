using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] FloatingHealthBar healthBar;
    private UIManager uIManager;
    public bool isAlive = true;
    private Slider BloodBar;
    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //currentHealth = maxHealth;
        currentHealth = DataManager.instance.health;
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        healthBar.UpdateHealthBar(currentHealth,maxHealth);
        BloodBar = GameObject.FindWithTag("Player").GetComponentInChildren<Slider>();
    }

    public void TakeDamage(int damage)
    {
        if (!isAlive) return;
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        DataManager.instance.health = currentHealth;
		GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayHurt();
		Debug.Log(currentHealth.ToString());
        if (currentHealth <= 0) {
			GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();
			GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayDeath();
			Die();
         }
    }

    private void Die()
    {
        //rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("isDeath");
        BloodBar.gameObject.SetActive(false);
        isAlive = false;
        uIManager.GameOver();
    }
   
}
