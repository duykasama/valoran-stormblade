using UnityEngine;

public class Spikehead : MonoBehaviour
{
    [Header("SpikeHead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[4];
    private Vector3 destination;
    private float checkTimer;
    private bool attacking;
    private int checkAttack = 0;
    [SerializeField] protected int damage2;
    [Header("SFX")]
    [SerializeField] private AudioClip impactSound;
    private bool checkHitting = false;

    private void OnEnable()
    {
        Stop();
    }
    private void Update()
    {
        //Move spikehead to destination only if attacking
       if(!checkHitting)
        {
            if (attacking)
                transform.Translate(destination * Time.deltaTime * speed);
            else
            {
                checkTimer += Time.deltaTime;
                if (checkTimer > checkDelay)
                    CheckForPlayer();
            }
        }
    }
    private void CheckForPlayer()
    {
        CalculateDirections();
        checkAttack += 1;
        //Check if spikehead sees player in all 4 directions
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if (hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
        if (checkAttack == 1)
        {
            Stop();
        }
    }
    private void CalculateDirections()
    {
        directions[0] = transform.right * range; //Right direction
        directions[1] = -transform.right * range; //Left direction
        directions[2] = transform.up * range; //Up direction
        directions[3] = -transform.up * range; //Down direction
    }
    private void Stop()
    {
        destination = transform.position; //Set destination as current position so it doesn't move
        attacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*        SoundManager.instance.PlaySound(impactSound);
        */
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<HealthPlayer>() != null)
            {
                collision.GetComponent<HealthPlayer>().TakeDamage(damage2);
                checkHitting = true;
            }
        }
        Stop(); //Stop spikehead once he hits something
    }
}