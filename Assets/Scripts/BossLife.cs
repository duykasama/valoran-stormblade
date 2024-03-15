using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float detectionRange = 30f;
    [SerializeField] private float toAttackRange = 8f;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float attackCooldown = 2f;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    private Animator anim;
    private Transform player;
    private SpriteRenderer spriteRenderer;
    private bool isAttacking = false;
    public bool isAlive = true;
    private float lastAttackTime = 0f;
    private HealthPlayer playerHealth;
    [SerializeField]private float toShootRange = 15f;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;
    private float cooldownTimer = Mathf.Infinity;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<HealthPlayer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player != null && isAlive)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange)
            {
                Debug.Log("12345");
                Vector3 direction = player.position - transform.position;
                direction.y = 0f;
                direction.Normalize();

                if (distanceToPlayer <= toAttackRange && playerHealth.isAlive)
                {
                    if (!isAttacking && Time.time - lastAttackTime >= attackCooldown)
                    {
                        Debug.Log("Attack");
                        Attack();
                        lastAttackTime = Time.time;
                        anim.SetBool("isMoving", false);
                    }
                }
                else 
                {
                    transform.position += direction * moveSpeed * Time.deltaTime;

                    if (direction.x < 0)
                    {
                        spriteRenderer.flipX = true;
                        anim.SetBool("isMoving", true);
                        attackPoint.localPosition = new Vector3(-0.95f, -0.75f, 0f);
                    }
                    else if (direction.x > 0)
                    {
                        spriteRenderer.flipX = false;
                        anim.SetBool("isMoving", true);
                        attackPoint.localPosition = new Vector3(0.95f, -0.75f, 0f);
                    }
                    else
                    {
                        
                        anim.SetBool("isMoving", false);
                    }
                    isAttacking = false;
                }

            }
            else
            {
                RangedAttack();
                anim.SetBool("isMoving", false);
                isAttacking = false;
            }
        }
    }

    public void Attack()
    {
        anim.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        foreach (var hitEnemy in hitEnemies)
        {
            if (hitEnemy.CompareTag("Player"))
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = firepoint.position;
        fireballs[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
