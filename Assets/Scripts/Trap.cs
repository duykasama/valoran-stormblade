using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damagePerSecond = 5;
    private HealthPlayer playerHealth;

    public void Start()
    {
        playerHealth = FindObjectOfType<HealthPlayer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        InvokeRepeating("ApplyDamage", 0f, 1f);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CancelInvoke("ApplyDamage");
    }

    private void ApplyDamage()
    {
        playerHealth.TakeDamage(damagePerSecond);
    }
}
