using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("touch");
            HealthPlayer playerHealth = GetComponent<HealthPlayer>();
            if (playerHealth != null) {
                playerHealth.TakeDamage(10);
            }
        }
    }
  

}
