using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SantoAttacks : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform attackPoint;
    public float attackRadius = 1;
    public Transform specialAttackPoint;
    public float specialAttackRadius = 1;
    public LayerMask attackableLayer;
    public int damage;
    public int specialDamage;
    private PlayerMovementSantoP1 player1;
    private PlayerMovementSantoP2 player2;
    private PlayerMovementKalimanP1 playerKalimanP1;
    private PlayerMovementKalimanP2 playerKalimanP2;
    private PlayerMovementSantoP1 playerSantoP1;
    private PlayerMovementSantoP2 playerSantoP2;
    private SantoAttacks santoAttacks;
    public float timeBetweenAttacks = 0.3f;
    public float timeBetweenSpecialAtack = 10f;
    private float attackTimeCounter;
    private float specialTimeCounter;
    private Slider MeterP1;
    private Slider MeterP2;
    public VideoPlayer Video;

    //private Sounds sounds;

    private void Start()
    {
        santoAttacks = GetComponent<SantoAttacks>();
        Video = GameObject.FindGameObjectWithTag("VideoSanto").GetComponent<VideoPlayer>();
        player1 = GetComponent<PlayerMovementSantoP1>();
        player2 = GetComponent<PlayerMovementSantoP2>();
        MeterP1 = GameObject.FindGameObjectWithTag("MeterP1").GetComponent<Slider>();
        MeterP2 = GameObject.FindGameObjectWithTag("MeterP2").GetComponent<Slider>();
        playerKalimanP1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovementKalimanP1>();
        playerKalimanP2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovementKalimanP2>();
        playerSantoP1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovementSantoP1>();
        playerSantoP2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovementSantoP2>();

        //specialAttackVideo = GameObject.FindGameObjectWithTag("VideoSanto").gET

        attackTimeCounter = timeBetweenAttacks;
        specialTimeCounter = timeBetweenAttacks;
        if (MeterP1 != null)
        {
            MeterP1.value = 0f;
        }

        if (MeterP2 != null)
        {
            MeterP2.value = 0f;
        }
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
        if (player1 != null && Input.GetKeyDown(KeyCode.G) && specialTimeCounter >= timeBetweenSpecialAtack)
        {
            specialTimeCounter = 0f;
            //sounds.attack();
            //Player.animator.SetTrigger("attacking");
            SpecialAttack();
        }

        else if (player2 != null && Input.GetKeyDown(KeyCode.K) && attackTimeCounter >= timeBetweenAttacks)
        {
            attackTimeCounter = 0f;
            //sounds.attack();
            //Player.animator.SetTrigger("attacking");
            Attack();
        }
        else if (player2 != null && Input.GetKeyDown(KeyCode.L) && specialTimeCounter >= timeBetweenSpecialAtack)
        {
            specialTimeCounter = 0f;
            //sounds.attack();
            //Player.animator.SetTrigger("attacking");
            SpecialAttack();
        }
        attackTimeCounter += Time.deltaTime;
        specialTimeCounter += Time.deltaTime;
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
                //hit.GetComponent<EnemyHealth>().animator.SetTrigger("Damage");
            }
            if (hit.GetComponent<HealthP1>() != null)
            {
                //sounds.hit();
                hit.GetComponent<HealthP1>().health -= damage;
                //hit.GetComponent<EnemyHealth>().animator.SetTrigger("Damage");
            }

            if ((hit.GetComponent<HealthP2>() != null && hit.GetComponent<HealthP2>().health <= 0) || (hit.GetComponent<HealthP1>() != null && hit.GetComponent<HealthP1>().health <= 0))
            {
                Debug.Log("wdwdwdwdwdwd");
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
                if (playerSantoP2  != null)
                {
                    playerSantoP2.enabled = false;
                }
                santoAttacks.enabled = true;
                //sounds.hit();
                //hit.GetComponent<EnemyHealth>().animator.SetTrigger("Damage");
            }
        }
    }

    public void SpecialAttack()
    {

        if (player1 != null)
        {
            StartCoroutine(AttackingP1(timeBetweenAttacks));
            StartCoroutine(FillSliderOverTimeMeterP1());
        }

        if (player2 != null)
        {
            StartCoroutine(AttackingP2(timeBetweenAttacks));
            StartCoroutine(FillSliderOverTimeMeterP1());
        }

        Collider2D[] hits = Physics2D.OverlapCircleAll(specialAttackPoint.position, specialAttackRadius, attackableLayer);
        foreach (Collider2D hit in hits)
        {
            if (hit.GetComponent<HealthP2>() != null)
            {
                //sounds.hit();
                Video.enabled = true;
                Video.Play();
                StartCoroutine(SpecialAttackingP1());
                hit.GetComponent<HealthP2>().health -= specialDamage;

                //hit.GetComponent<EnemyHealth>().animator.SetTrigger("Damage");
            }

            if (hit.GetComponent<HealthP1>() != null)
            {
                //sounds.hit();
                Video.enabled = true;
                Video.Play();
                StartCoroutine(SpecialAttackingP2());
                hit.GetComponent<HealthP1>().health -= specialDamage;
                //hit.GetComponent<EnemyHealth>().animator.SetTrigger("Damage");
            }

            if ((hit.GetComponent<HealthP2>() != null && hit.GetComponent<HealthP2>().health <= 0) || (hit.GetComponent<HealthP1>() != null && hit.GetComponent<HealthP1>().health <= 0))
            {
                Debug.Log("wdwdwdwdwdwd");
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
                santoAttacks.enabled = true;
                //sounds.hit();
                //hit.GetComponent<EnemyHealth>().animator.SetTrigger("Damage");
            }
        }
    }

    private IEnumerator AttackingP1(float timeAttack)
    {
        player1.isAttacking = true;
        yield return new WaitForSeconds(timeAttack);
        player1.isAttacking = false;
    }

    private IEnumerator AttackingP2(float timeAttack)
    {
        player2.isAttacking = true;
        yield return new WaitForSeconds(timeAttack);
        player2.isAttacking = false;
    }

    private IEnumerator SpecialAttackingP1()
    {
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
        player1.isAttacking = true;

        yield return new WaitForSeconds(4f);

        player1.isAttacking = false;
        if (playerKalimanP1 != null)
        {
            playerKalimanP1.enabled = true;
        }
        if (playerKalimanP2 != null)
        {
            playerKalimanP2.enabled = true;
        }
        if (playerSantoP1 != null)
        {
            playerSantoP1.enabled = true;
        }
        if (playerSantoP2 != null)
        {
            playerSantoP2.enabled = true;
        }
        Video.Pause();
        Video.enabled = false;
    }

    private IEnumerator SpecialAttackingP2()
    {
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
        player2.isAttacking = true;

        yield return new WaitForSeconds(4f);

        player2.isAttacking = false;
        if (playerKalimanP1 != null)
        {
            playerKalimanP1.enabled = true;
        }
        if (playerKalimanP2 != null)
        {
            playerKalimanP2.enabled = true;
        }
        if (playerSantoP1 != null)
        {
            playerSantoP1.enabled = true;
        }
        if (playerSantoP2 != null)
        {
            playerSantoP2.enabled = true;
        }
        Video.Pause();
        Video.enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(specialAttackPoint.position, specialAttackRadius);
    }

    private IEnumerator FillSliderOverTimeMeterP1()
    {
        float elapsedTime = 0f;
        float startValue = 0f;
        float targetValue = 10f;

        // The loop continues as long as the elapsed time is less than the duration
        while (elapsedTime < 10f)
        {
            // Calculate the new value using Mathf.Lerp for smooth, frame-rate independent updates
            // The third parameter (elapsedTime / fillDuration) goes from 0 to 1 over the duration
            MeterP1.value = Mathf.Lerp(startValue, targetValue, elapsedTime / 10f);

            // Increment the elapsed time by the time since the last frame
            elapsedTime += Time.deltaTime;

            // Wait until the next frame before continuing the loop
            yield return null;
        }

        // Ensure the slider reaches the exact max value when the time is up
        MeterP1.value = targetValue;
    }

    private IEnumerator FillSliderOverTimeMeterP2()
    {
        float elapsedTime = 0f;
        float startValue = 0f;
        float targetValue = 10f;

        // The loop continues as long as the elapsed time is less than the duration
        while (elapsedTime < 10f)
        {
            // Calculate the new value using Mathf.Lerp for smooth, frame-rate independent updates
            // The third parameter (elapsedTime / fillDuration) goes from 0 to 1 over the duration
            MeterP2.value = Mathf.Lerp(startValue, targetValue, elapsedTime / 10f);

            // Increment the elapsed time by the time since the last frame
            elapsedTime += Time.deltaTime;

            // Wait until the next frame before continuing the loop
            yield return null;
        }
        // Ensure the slider reaches the exact max value when the time is up
        MeterP2.value = targetValue;
    }

}