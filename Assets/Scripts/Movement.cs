using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public bool isGrounded = false;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private Transform enemyA;
    private Transform enemyB;
    private HealthPlayer player;
   
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private int damageAmount = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyA = GameObject.FindGameObjectWithTag("EnemyA").transform;
        enemyB = GameObject.FindGameObjectWithTag("EnemyB").transform;
        player = GetComponent<HealthPlayer>();
        moveSpeed = DataManager.instance.speed;
        damageAmount = DataManager.instance.damage;
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.isAlive)
        {
            dirX = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (!isGrounded && rb.velocity.y < 0)
            {
                animator.SetBool("isFalling", true);
            }
            else
            {
                animator.SetBool("isFalling", false);
            }

            if (Input.GetMouseButtonDown(1))
            {
                Attack();
            }
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                animator.SetBool("isJumping", true);
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
            UpdateANimation();
        }
    }


    private void UpdateANimation()
    {
        if (dirX > 0f)
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = false;
            attackPoint.localPosition = new Vector3(1, 1, 0);
        }
        else if (dirX < 0f)
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = true;
            attackPoint.localPosition = new Vector3(-1, 1, 0);

        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    public void Attack()
    {
        animator.SetTrigger("isAttacking");
        HealthEnemyA enemyHealthA = enemyA.GetComponent<HealthEnemyA>();
        HealthEnemyB enemyHealthB = enemyB.GetComponent<HealthEnemyB>();
        Debug.Log(enemyHealthA.currentHealth.ToString());
        Debug.Log(enemyHealthB.currentHealth.ToString());
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D hitEnemy in hitEnemies)
        {
            if (hitEnemy.CompareTag("EnemyA"))
            {
                Debug.Log("hit enemy A");
                enemyHealthA.TakeDamage(damageAmount);
            }
            if (hitEnemy.CompareTag("EnemyB"))
            {
                Debug.Log("hit enemy B");
                enemyHealthB.TakeDamage(damageAmount);
            }
        }
    }
    

    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
