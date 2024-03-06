using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] FloatingHealthBar healthBar;
    private EnemyLife enemyLife;

   
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        enemyLife = GetComponent<EnemyLife>();
    }

    public void TakeDamage(int damage)
    {
        if (enemyLife.isAlive == false) return;
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        Debug.Log(currentHealth.ToString());
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //rb.bodyType = RigidbodyType2D.Static;
        enemyLife.isAlive = false;
        anim.SetTrigger("die");
        StartCoroutine(DeactivateAfterDelay(1f));
    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
