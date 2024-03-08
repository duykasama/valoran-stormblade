using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sideways_Diagonal : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private bool movingUpRight;
    private Vector3 startingPosition;
    private Vector3 destinationPosition;

    private void Start()
    {
        startingPosition = transform.position;
        destinationPosition = startingPosition + new Vector3(movementDistance, movementDistance, 0);
    }

    private void Update()
    {
        // Move towards destination
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, speed * Time.deltaTime);

        // Check if reached destination
        if (Vector3.Distance(transform.position, destinationPosition) <= 0.01f)
        {
            // Swap direction
            movingUpRight = !movingUpRight;

            // Update destination
            if (movingUpRight)
            {
                destinationPosition = startingPosition + new Vector3(movementDistance, movementDistance, 0);
            }
            else
            {
                destinationPosition = startingPosition - new Vector3(movementDistance, movementDistance, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
