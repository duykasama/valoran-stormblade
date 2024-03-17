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
            HealthPlayer playerHealth = GetComponent<HealthPlayer>();
            if (playerHealth != null) {
                playerHealth.TakeDamage(10);
            }
        }
         else if (collision.gameObject.CompareTag("SuperTrap"))
        {
            HealthPlayer playerHealth = GetComponent<HealthPlayer>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(100);
            }
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("ShopScene");
        }
		else if (collision.gameObject.CompareTag("Victory"))
		{
			SceneManager.LoadScene("Victory");
		}
	}
  

}
