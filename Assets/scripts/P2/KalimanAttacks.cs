using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Video;

public class KalimanAttacks : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform attackPoint;
    public float attackRadius = 1;
    public Transform specialAttackPoint;
    public float specialAttackRadius = 1;
    public LayerMask attackableLayer;
    public int damage;
    public int specialDamage;
    private PlayerMovementKalimanP1 player1;
    private PlayerMovementKalimanP2 player2;
    private PlayerMovementSantoP1 playerSantoP1;
    private PlayerMovementSantoP2 playerSantoP2;
    private PlayerMovementKalimanP1 playerKalimanP1;
    private PlayerMovementKalimanP2 playerKalimanP2;
    private KalimanAttacks kalimanAttacks;

    private KalimanAttacks EnemyKaliman;
    private SantoAttacks EnemySanto;

    public float timeBetweenAttacks = 0.3f;
    public float timeBetweenSpecialAtack = 10f;
    private float attackTimeCounter;
    private float specialTimeCounter;
    private Slider MeterP1;
    private Slider MeterP2;
    private VideoPlayer Video;

    private SonidosKaliman sounds;

    private void Start()
    {
        sounds = GetComponent<SonidosKaliman>();
        kalimanAttacks = GetComponent<KalimanAttacks>();
        Video = GameObject.FindGameObjectWithTag("VideoKaliman").GetComponent<VideoPlayer>();
        player1 = GetComponent<PlayerMovementKalimanP1>();
        player2 = GetComponent<PlayerMovementKalimanP2>();
        MeterP1 = GameObject.FindGameObjectWithTag("MeterP1").GetComponent<Slider>();
        MeterP2 = GameObject.FindGameObjectWithTag("MeterP2").GetComponent<Slider>();
        playerSantoP1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovementSantoP1>();
        playerSantoP2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovementSantoP2>();
        playerKalimanP1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovementKalimanP1>();
        playerKalimanP2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovementKalimanP2>();

        attackTimeCounter = timeBetweenAttacks;
        specialTimeCounter = timeBetweenAttacks;
        //sounds = GameObject.FindGameObjectWithTag("Player").GetComponent<Sounds>();

        if (MeterP1 != null)
        {
            MeterP1.value = 10f;
        }

        if (MeterP2 != null)
        {
            MeterP2.value = 10f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 != null && Input.GetKeyDown(KeyCode.F) && attackTimeCounter >= timeBetweenAttacks)
        {
            attackTimeCounter = 0f;
            //sounds.attack();
            if (player1 != null)
            {
                player1.animator.SetTrigger("attacking");
            }
            else if (player2 != null)
            {
                player2.animator.SetTrigger("attacking");
            }
            sounds.WhiffAttack();
            Attack();
        }
        else if (player1 != null && Input.GetKeyDown(KeyCode.G) && specialTimeCounter >= timeBetweenSpecialAtack)
        {
            specialTimeCounter = 0f;
            //sounds.attack();
            if (player1 != null)
            {
                player1.animator.SetTrigger("attacking");
            }
            else if (player2 != null)
            {
                player2.animator.SetTrigger("attacking");
            }
            sounds.WhiffAttack();
            SpecialAttack();
        }

        else if (player2 != null && Input.GetKeyDown(KeyCode.K) && attackTimeCounter >= timeBetweenAttacks)
        {
            attackTimeCounter = 0f;
            //sounds.attack();
            if (player1 != null)
            {
                player1.animator.SetTrigger("attacking");
            }
            else if (player2 != null)
            {
                player2.animator.SetTrigger("attacking");
            }
            sounds.WhiffAttack();
            Attack();
        }
        else if (player2 != null && Input.GetKeyDown(KeyCode.L) && specialTimeCounter >= timeBetweenSpecialAtack)
        {
            specialTimeCounter = 0f;
            //sounds.attack();
            if (player1 != null)
            {
                player1.animator.SetTrigger("attacking");
            }
            else if (player2 != null)
            {
                player2.animator.SetTrigger("attacking");
            }
            sounds.WhiffAttack();
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
                hit.GetComponent<HealthP2>().health -= damage;
                Debug.Log("wwww");
                sounds.attack();
                if (hit.GetComponent<HealthP2>().soundsKaliman != null)
                {
                    hit.GetComponent<HealthP2>().soundsKaliman.damage();
                    hit.GetComponent<HealthP2>().animator.SetTrigger("Damage");
                }
                if (hit.GetComponent<HealthP2>().soundsSanto != null)
                {
                    hit.GetComponent<HealthP2>().soundsSanto.damage();
                    hit.GetComponent<HealthP2>().animator.SetTrigger("Damage");
                }
                
            }
            if (hit.GetComponent<HealthP1>() != null)
            {
                hit.GetComponent<HealthP1>().health -= damage;
                Debug.Log("wwww");
                sounds.attack();
                if (hit.GetComponent<HealthP1>().soundsKaliman != null)
                {
                    hit.GetComponent<HealthP1>().soundsKaliman.damage();
                    hit.GetComponent<HealthP1>().animator.SetTrigger("Damage");
                }
                if (hit.GetComponent<HealthP1>().soundsSanto != null)
                {
                    hit.GetComponent<HealthP1>().soundsSanto.damage();
                    hit.GetComponent<HealthP1>().animator.SetTrigger("Damage");
                }
                
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
                kalimanAttacks.enabled = false;
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
            StartCoroutine(FillSliderOverTimeMeterP2());
        }

        Collider2D[] hits = Physics2D.OverlapCircleAll(specialAttackPoint.position, attackRadius, attackableLayer);
        foreach (Collider2D hit in hits)
        {
            if (hit.GetComponent<HealthP2>() != null)
            {
                //sounds.hit();
                Video.enabled = true;
                Video.Play();
                hit.GetComponent<HealthP2>().health -= specialDamage;
                StartCoroutine(SpecialAttackingP1());
                sounds.attack();
                if (hit.GetComponent<HealthP2>().soundsKaliman != null)
                {
                    hit.GetComponent<HealthP2>().soundsKaliman.damage();
                }
                if (hit.GetComponent<HealthP2>().soundsSanto != null)
                {
                    hit.GetComponent<HealthP2>().soundsSanto.damage();
                }
                if (hit.GetComponent<SantoAttacks>() != null)
                {
                    EnemySanto = hit.GetComponent<SantoAttacks>();
                    EnemySanto.enabled = false;
                }
                if (hit.GetComponent<KalimanAttacks>() != null)
                {
                    EnemyKaliman = hit.GetComponent<KalimanAttacks>();
                    EnemyKaliman.enabled = false;
                }
                //hit.GetComponent<EnemyHealth>().animator.SetTrigger("Damage");
            }

            if (hit.GetComponent<HealthP1>() != null)
            {
                //sounds.hit();
                Video.enabled = true;
                Video.Play();
                hit.GetComponent<HealthP1>().health -= specialDamage;
                StartCoroutine(SpecialAttackingP2());
                sounds.attack();
                if (hit.GetComponent<HealthP1>().soundsKaliman != null)
                {
                    hit.GetComponent<HealthP1>().soundsKaliman.damage();
                }
                if (hit.GetComponent<HealthP1>().soundsSanto != null)
                {
                    hit.GetComponent<HealthP1>().soundsSanto.damage();
                }
                if (hit.GetComponent<SantoAttacks>() != null)
                {
                    EnemySanto = hit.GetComponent<SantoAttacks>();
                    EnemySanto.enabled = false;
                }
                if (hit.GetComponent<KalimanAttacks>() != null)
                {
                    EnemyKaliman = hit.GetComponent<KalimanAttacks>();
                    EnemyKaliman.enabled = false;
                }
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
                kalimanAttacks.enabled = false;
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
        kalimanAttacks.enabled = false;

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
        kalimanAttacks.enabled = true;
        if (EnemySanto != null)
        {
            EnemySanto.enabled = true;
        }
        if (EnemyKaliman != null)
        {
            EnemyKaliman.enabled = true;
        }
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
        kalimanAttacks.enabled = false;

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
        kalimanAttacks.enabled = true;
        if (EnemySanto != null)
        {
            EnemySanto.enabled = true;
        }
        if (EnemyKaliman != null)
        {
            EnemyKaliman.enabled = true;
        }
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
