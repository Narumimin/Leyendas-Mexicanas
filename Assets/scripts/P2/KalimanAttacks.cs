using UnityEngine;
using System.Collections;

public class KalimanAttacks : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform attackPoint;
    public float attackRadius = 1;
    public LayerMask attackableLayer;
    public int damage;
    private PlayerMovementKalimanP1 player1;
    private PlayerMovementKalimanP2 player2;
    private PlayerMovementSantoP1 playerSantoP1;
    private PlayerMovementSantoP2 playerSantoP2;
    private PlayerMovementKalimanP1 playerKalimanP1;
    private PlayerMovementKalimanP2 playerKalimanP2;
    private KalimanAttacks kalimanAttacks;
    public float timeBetweenAttacks = 0.3f;
    private float attackTimeCounter;
    //private Sounds sounds;

    private void Start()
    {
        kalimanAttacks = GetComponent<KalimanAttacks>();
        player1 = GetComponent<PlayerMovementKalimanP1>();
        player2 = GetComponent<PlayerMovementKalimanP2>();
        playerSantoP1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovementSantoP1>();
        playerSantoP2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovementSantoP2>();
        playerKalimanP1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovementKalimanP1>();
        playerKalimanP2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovementKalimanP2>();

        attackTimeCounter = timeBetweenAttacks;
        //sounds = GameObject.FindGameObjectWithTag("Player").GetComponent<Sounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 != null && Input.GetKeyDown(KeyCode.F) && attackTimeCounter >= timeBetweenAttacks)
        {
            attackTimeCounter = 0f;
            //sounds.attack();
            //Player.animator.SetTrigger("attacking");
            Attack();
        }
        else if (player2 != null && Input.GetKeyDown(KeyCode.K) && attackTimeCounter >= timeBetweenAttacks)
        {
            attackTimeCounter = 0f;
            //sounds.attack();
            //Player.animator.SetTrigger("attacking");
            Attack();
        }
        attackTimeCounter += Time.deltaTime;
    }

    public void Attack()
    {

        if (player1 != null)
        {
            StartCoroutine(AttackingP1(timeBetweenAttacks));
        }

        if (player2 != null)
        {
            StartCoroutine(AttackingP2(timeBetweenAttacks));
        }

        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, attackableLayer);
        foreach (Collider2D hit in hits)
        {
            if (hit.GetComponent<HealthP2>() != null)
            {
                //sounds.hit();
                hit.GetComponent<HealthP2>().health -= damage;
                Debug.Log("wwww");
                //hit.GetComponent<EnemyHealth>().animator.SetTrigger("Damage");
            }
            if (hit.GetComponent<HealthP1>() != null)
            {
                //sounds.hit();
                hit.GetComponent<HealthP1>().health -= damage;
                Debug.Log("wwww");
                //hit.GetComponent<EnemyHealth>().animator.SetTrigger("Damage");
            }

            if ((hit.GetComponent<HealthP2>() != null && hit.GetComponent<HealthP2>().health <= 0) || (hit.GetComponent<HealthP1>() != null && hit.GetComponent<HealthP1>().health <= 0))
            {
                Debug.Log("wdwdwdwdwdwd");
                if (player1 != null)
                {
                    player1.enabled = false;
                }
                if (player2 != null)
                {
                    player2.enabled = false;
                }
                if (playerKalimanP1 != null)
                {
                    playerKalimanP1.enabled = false;
                }
                if (playerKalimanP2 != null)
                {
                    playerKalimanP2.enabled = false;
                }
                if (playerSantoP1 != null)
                {
                    playerSantoP1.enabled = false;
                }
                if (playerSantoP2 != null)
                {
                    playerSantoP2.enabled = false;
                }
                kalimanAttacks.enabled = false;
                //sounds.hit();
                //hit.GetComponent<EnemyHealth>().animator.SetTrigger("Damage");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    private IEnumerator AttackingP1(float timeAttack)
    {
        player1.isCrouching = true;
        yield return new WaitForSeconds(timeAttack);
        player1.isCrouching = false;
    }

    private IEnumerator AttackingP2(float timeAttack)
    {
        player2.isCrouching = true;
        yield return new WaitForSeconds(timeAttack);
        player2.isCrouching = false;
    }
}
